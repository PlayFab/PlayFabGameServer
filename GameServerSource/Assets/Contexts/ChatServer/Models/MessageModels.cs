using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ChatMessage : MessageBase
{
    public string ChannelId;
    public string SenderUserId;
    public string SenderUserName;
    public string Message;
    public DateTime Timestamp;

    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(ChannelId);
        writer.Write(SenderUserId);
        writer.Write(SenderUserName);
        writer.Write(Message);
        var json = PlayFab.SimpleJson.SerializeObject(Timestamp);
        writer.Write(json);
    }

    public override void Deserialize(NetworkReader reader)
    {
        ChannelId = reader.ReadString();
        SenderUserId = reader.ReadString();
        SenderUserName = reader.ReadString();
        Message = reader.ReadString();
        Timestamp = PlayFab.SimpleJson.DeserializeObject<DateTime>(reader.ReadString());
    }
}

public class CreateChannelMessage : MessageBase
{
    public string ChannelId = Guid.NewGuid().ToString();
    public string MemberId;
    public string MemberName;
	public bool isInviteOnly = true;
}

public class CreateChannelResponseMessage : MessageBase
{
    public string ChannelId;
    public string MemberId;
    public bool Created;
    public string Error;
}

public class LeaveChannelMessage : MessageBase
{
    public string ChannelId;
    public string MemberId;
}

public class JoinChannelMessage : MessageBase
{
    public string ChannelId;
    public string MemberId;
    public string MemberName;
}

public class JoinChannelResponseMessage : MessageBase
{
    public string ChannelId;
    public string MemberId;
    public bool Joined;
    public string Error;
}