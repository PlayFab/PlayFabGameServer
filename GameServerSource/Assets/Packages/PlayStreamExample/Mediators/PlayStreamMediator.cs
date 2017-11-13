using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using PlayFab;
using PlayFab.Json;
using PlayFab.PlayStreamModels;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;

public class PlayStreamMediator : Mediator
{
    [Inject]
    public PlayStreamView View { get; set; }
    [Inject]
    public UnityNetworkingData NetworkingData { get; set; }

    public override void OnRegister()
    {
        Debug.Log("Registering for PlayStream Events");
        PlayFabPlayStreamAPI.Start();
        PlayFabPlayStreamAPI.OnPlayStreamEvent += notif =>
        {
            Debug.Log("received event, entity type is " + notif.EntityType);
            if (notif.EntityType != "title")
            {
                //this is a player/character-specific event
                OnPlayerEventHappened(notif);
            }
            else
            {
                //this is a title-specific event, could broadcast
                Debug.Log("about to send some title events");
                OnTitleEventHappened(notif);
            }
        };

        PlayFabPlayStreamAPI.OnSubscribed += () =>
        {
            Debug.Log("Connected to playstream");
        };
        PlayFabPlayStreamAPI.OnFailed += error =>
        {
            Debug.Log(error.Message);
        };
        PlayFabPlayStreamAPI.OnDisconnected += () =>
        {
            Debug.Log("Disconnected");
        };
        PlayFabPlayStreamAPI.OnError += Debug.LogException;


        NetworkServer.RegisterHandler(PlayStreamMsgTypes.RegisterForEvents, OnRegisterForEvent);
        NetworkServer.RegisterHandler(PlayStreamMsgTypes.RequestForFriendList, OnReceivedRequestForFriendList);
    }

    public override void OnRemove()
    {

    }

    private void OnTitleEventHappened(PlayStreamNotification notif)
    {
        if (notif.EventName != "title_statistic_version_changed") return;
        foreach (var conn in NetworkingData.Connections)
        {
            conn.Connection.Send(PlayStreamMsgTypes.OnPlayStreamEventReceived, new PlayStreamEventMessage() { EntityType = notif.EntityType, EventData = notif.EventObject.EventData.ToString(), EventName = notif.EventName, EventNamespace = notif.EventNamespace });
        }
    }

    private void OnPlayerEventHappened(PlayStreamNotification notif)
    {
        var eventToSend = View.Subscriptions.Find(s => s.PlayFabId == notif.PlayerId);
        if (eventToSend != null)
        {
            var conn = NetworkingData.Connections.Find(c => c.PlayFabId == eventToSend.PlayFabId);
            if (conn == null)
            {
                View.Subscriptions.Remove(eventToSend);
            }
            else
            {
                conn.Connection.Send(PlayStreamMsgTypes.OnPlayStreamEventReceived, new PlayStreamEventMessage() { EventData = notif.EventObject.EventData.ToString(), EventName = notif.EventName, EntityType = notif.EntityType, EventNamespace = notif.EventNamespace });
            }
        }
    }

    private void OnRegisterForEvent(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<RegisterForEventsMessage>();
        if (message == null) return;

        var finded = View.Subscriptions.Find(c => c.PlayFabId == message.Subscription.PlayFabId);
        if (finded != null)
        {
            View.Subscriptions.Remove(finded);
            View.Subscriptions.Add(message.Subscription);
        }
        else
        {
            View.Subscriptions.Add(message.Subscription);
        }
    }

    private void OnReceivedRequestForFriendList(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<AskForFriendListMessage>();
        if (message == null) return;
        var data = View.Subscriptions.Select(s => s.PlayFabId);
        netmsg.conn.Send(PlayStreamMsgTypes.OnSendFriendsList, new FriendListMessage() { PlayfabIds = data.ToArray() });
    }
}
