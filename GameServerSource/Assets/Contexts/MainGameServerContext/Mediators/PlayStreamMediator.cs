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
        PlayFabPlayStreamAPI.OnPlayStreamEvents += notif =>
        {
            var psevent = JsonWrapper.DeserializeObject<PlayerInventoryItemAddedEvent>(notif.EventObject.EventData.ToString());

            Debug.Log("received event, entity type is " + psevent.EntityType);
            if (psevent.EntityType != "title")
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
            Debug.Log("connected to playstream");
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
        var psevent = JsonWrapper.DeserializeObject<PlayerInventoryItemAddedEvent>(notif.EventObject.EventData.ToString());
        foreach (var conn in NetworkingData.Connections)
        {
            conn.Connection.Send(PlayStreamMsgTypes.OnPlayStreamEventReceived, new PlayStreamEventMessage() { EntityType = psevent.EntityType, EventData = notif.EventObject.EventData.ToString(), EventName = psevent.EventName, EventNamespace = psevent.EventNamespace });
        }
    }

    private void OnPlayerEventHappened(PlayStreamNotification notif)
    {
        var eventToSend = View.Subscriptions.Find(s => s.PlayFabId == notif.PlayerId);
        var psevent = JsonWrapper.DeserializeObject<PlayerInventoryItemAddedEvent>(notif.EventObject.EventData.ToString());
        if (eventToSend != null)
        {
            var conn = NetworkingData.Connections.Find(c => c.PlayFabId == eventToSend.PlayFabId);
            if (conn == null)
            {
                View.Subscriptions.Remove(eventToSend);
            }
            else
            {
                conn.Connection.Send(PlayStreamMsgTypes.OnPlayStreamEventReceived, new PlayStreamEventMessage() { EventData = notif.EventObject.EventData.ToString(), EventName = psevent.EventName, EntityType = psevent.EntityType, EventNamespace = psevent.EventNamespace });
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
