using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ServerModels;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;


public class CreateChannelSignal : Signal<CreateChannelMessage> { }
public class CreateChannelCommand : Command
{
    [Inject] public CreateChannelMessage Message { get; set; }
    [Inject] public ChatServerData ChatServerData { get; set; }
    [Inject] public SendCreateChannelReponseSignal Signal { get; set; }
    [Inject] public WriteTitleEventSignal WriteTitleEventSignal { get; set; }
    [Inject] public WritePlayerEventSignal WritePlayerEventSignal { get; set; }
    [Inject] public ServerSettingsData ServerSettings { get; set; }

    public override void Execute()
    {
        var channel = ChatServerData.ServerChannels.Find(c => c.ChannelId == Message.ChannelId);
        if (channel == null)
        {
            var newChannel = new ChatChannel()
            {
                ChannelId = Message.ChannelId,
				IsInviteOnly = Message.IsInviteOnly

            };
            newChannel.Members.Add(new ChatChannelMember()
            {
                MemberId = Message.MemberId,
                MemberName = Message.MemberName
            });
            ChatServerData.ServerChannels.Add(newChannel);
            Signal.Dispatch(new CreateChannelResponseMessage()
            {
                MemberId = Message.MemberId,
                ChannelId = newChannel.ChannelId,
                Created =  true
            });
            WriteTitleEventSignal.Dispatch(new WriteTitleEventRequest()
            {
                EventName = "NewChatChannelCreated",
                Body = new Dictionary<string, object>()
                {
                    {"ChannelId", newChannel.ChannelId},
                    {"GameId", ServerSettings.GameId},
                    {"CreatedBy", Message.MemberId }
                }
            });
            WritePlayerEventSignal.Dispatch(new WriteServerPlayerEventRequest()
            {
                EventName = "PlayerJoinedChat",
                PlayFabId = Message.MemberId,
                Body = new Dictionary<string, object>()
                {
                    {"ChannelId",  newChannel.ChannelId },
                }
            });
            return;
        }
        else if (channel.IsInviteOnly)
        {
            Signal.Dispatch(new CreateChannelResponseMessage()
            {
                MemberId = Message.MemberId,
                ChannelId = channel.ChannelId,
                Created = false,
                Error = "Channel already exists and you were not invited."
            });
        }
        else
        {
            channel.Members.Add(new ChatChannelMember()
            {
                MemberId = Message.MemberId,
                MemberName = Message.MemberName
            });
            Signal.Dispatch(new CreateChannelResponseMessage()
            {
                MemberId = Message.MemberId,
                ChannelId = channel.ChannelId,
                Created = true
            });
            WritePlayerEventSignal.Dispatch(new WriteServerPlayerEventRequest()
            {
                EventName = "PlayerJoinedChat",
                PlayFabId = Message.MemberId,
                Body = new Dictionary<string, object>()
                {
                    {"ChannelId",  channel.ChannelId },
                }
            });
        }

    }
}

public class JoinChannelSignal : Signal<JoinChannelMessage> { }

public class JoinChannelCommand : Command
{
    [Inject] public JoinChannelMessage Message { get; set; }
    [Inject] public SendJoinedReponseSignal Signal { get; set; }
    [Inject] public ChatServerData ChatServerData { get; set; }
    [Inject] public WritePlayerEventSignal WritePlayerEventSignal { get; set; }

    public override void Execute()
    {
        var channel = ChatServerData.ServerChannels.Find(c => c.ChannelId == Message.ChannelId);
        if (channel != null)
        {
            channel.Members.Add( new ChatChannelMember()
            {
                MemberId = Message.MemberId,
                MemberName = Message.MemberName
            });
            Signal.Dispatch(new JoinChannelResponseMessage()
            {
                ChannelId = Message.ChannelId,
                Joined = true
            });
            WritePlayerEventSignal.Dispatch(new WriteServerPlayerEventRequest()
            {
                EventName = "PlayerJoinedChat",
                PlayFabId = Message.MemberId,
                Body = new Dictionary<string, object>()
                {
                    {"ChannelId",  channel.ChannelId },
                }
            });
        }
        else
        {
            Signal.Dispatch(new JoinChannelResponseMessage()
            {
                ChannelId = Message.ChannelId,
                Joined = false,
                Error = "Failed to Join Server."
            });
        }
    }
}

public class LeaveChannelSignal : Signal<LeaveChannelMessage> { }

public class LeaveChannelCommand : Command
{
    [Inject] public LeaveChannelMessage Message { get; set; }
    [Inject] public ChatServerData ChatServerData { get; set; }
    [Inject] public WritePlayerEventSignal WritePlayerEventSignal { get; set; }
    [Inject] public WriteTitleEventSignal WriteTitleEventSignal { get; set; }
    [Inject] public ServerSettingsData ServerSettings { get; set; }

    public override void Execute()
    {
        var channel = ChatServerData.ServerChannels.Find(c => c.ChannelId == Message.ChannelId);
        if (channel != null)
        {
            var member = channel.Members.Find(m => m.MemberId == Message.MemberId);
            if (member != null)
            {
                channel.Members.Remove(member);
                WritePlayerEventSignal.Dispatch(new WriteServerPlayerEventRequest()
                {
                    EventName = "PlayerLeftChat",
                    PlayFabId = Message.MemberId,
                    Body = new Dictionary<string, object>()
                    {
                        {"ChannelId", channel.ChannelId}
                    }
                });

            }

            if (channel.Members.Count == 0 && channel.IsInviteOnly)
            {
                ChatServerData.ServerChannels.Remove(channel);
                WriteTitleEventSignal.Dispatch(new WriteTitleEventRequest()
                {
                    EventName = "ChatChannelRemoved",
                    Body = new Dictionary<string, object>()
                    {
                        {"ChannelId", channel.ChannelId},
                        {"GameId", ServerSettings.GameId},
                        {"LastPlayer", Message.MemberId}
                    }
                });

            }

        }
    }
}

public class SendMessageSignal : Signal<ChatMessage> { }

public class SendMessageCommand : Command
{
    [Inject] public ChatMessage Message { get; set; }
    [Inject] public ChatServerData ChatServerData { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public WritePlayerEventSignal WritePlayerEventSignal { get; set; }

    public override void Execute()
    {
        var channel = ChatServerData.ServerChannels.Find(c => c.ChannelId == Message.ChannelId);
        if (channel == null)
        {
            return;
        }
        foreach (var member in channel.Members)
        {
            var memberConn = UnityNetworkingData.Connections.Find(mc => mc.PlayFabId == member.MemberId);
            if (memberConn != null && memberConn.PlayFabId != Message.SenderUserId)
            {
                memberConn.Connection.Send(ChatServerMessageTypes.ChannelMessage, Message);
                Debug.Log("Message Sent to " + Message.SenderUserId);
                WritePlayerEventSignal.Dispatch(new WriteServerPlayerEventRequest()
                {
                    EventName = "PlayerSentMessage",
                    PlayFabId = Message.SenderUserId,
                    Body = new Dictionary<string, object>()
                    {
                        {"ChannelId", channel.ChannelId},
                        {"MessageSent",Message.Message }
                    }
                });
            }
        }
    }
}

public class SendJoinedReponseSignal : Signal<JoinChannelResponseMessage> { }

public class SendJoinedReponseCommand : Command
{
    [Inject] public JoinChannelResponseMessage Message { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }

    public override void Execute()
    {
        var playerConn = UnityNetworkingData.Connections.Find(c => c.PlayFabId == Message.MemberId);
        if (playerConn != null)
        {
            playerConn.Connection.Send(ChatServerMessageTypes.JoinChannelResponse, Message);
        }
    }
}

public class SendCreateChannelReponseSignal : Signal<CreateChannelResponseMessage> { }

public class SendCreateChannelReponseCommand : Command
{
    [Inject] public CreateChannelResponseMessage Message { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }

    public override void Execute()
    {
        var playerConn = UnityNetworkingData.Connections.Find(c => c.PlayFabId == Message.MemberId);
        if (playerConn != null)
        {
            playerConn.Connection.Send(ChatServerMessageTypes.CreateChannelResponse, Message);
        }
    }
}