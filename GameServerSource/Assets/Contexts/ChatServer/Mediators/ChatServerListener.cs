using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class ChatServerListener : Mediator {
    [Inject] public SendMessageSignal SendMessageSignal { get; set; }
    [Inject] public CreateChannelSignal CreateChannelSignal { get; set; }
    [Inject] public LeaveChannelSignal LeaveChannelSignal { get; set; }
    [Inject] public JoinChannelSignal JoinChannelSignal { get; set; }

    public override void OnRegister()
    {
        NetworkServer.RegisterHandler(ChatServerMessageTypes.CreateChannel, OnCreateChannel);
        NetworkServer.RegisterHandler(ChatServerMessageTypes.JoinChannel, OnJoinChannel);
        NetworkServer.RegisterHandler(ChatServerMessageTypes.LeaveChannel, OnLeaveChannel);
        NetworkServer.RegisterHandler(ChatServerMessageTypes.ChannelMessage, OnChannelMessage);
        NetworkServer.RegisterHandler(ChatServerMessageTypes.PrivateMessage, OnPrivateMessage);
    }

    private void OnPrivateMessage(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<ChatMessage>();
        if (message != null)
        {
            //TODO: Check if channel exists
            //TODO: If Channel doesn't exist, create channel between two Members, then send message.
            SendMessageSignal.Dispatch(message);
        }
    }

    private void OnChannelMessage(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<ChatMessage>();
        if (message != null)
        {
            SendMessageSignal.Dispatch(message);
        }
    }

    private void OnLeaveChannel(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<LeaveChannelMessage>();
        if (message != null)
        {
            LeaveChannelSignal.Dispatch(message);
        }
    }

    private void OnJoinChannel(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<JoinChannelMessage>();
        if (message != null)
        {
            JoinChannelSignal.Dispatch(message);
        }
    }

    private void OnCreateChannel(NetworkMessage netmsg)
    {
        var message = netmsg.ReadMessage<CreateChannelMessage>();
        if (message != null)
        {
            CreateChannelSignal.Dispatch(message);
        }
    }

}
