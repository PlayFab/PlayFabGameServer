using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ChatMessage : MessageBase
{
    public string Channel;
    public string SenderUserId;
    public string SenderUserName;
    public string Message;
    public DateTime Timestamp;

    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(Channel);
        writer.Write(SenderUserId);
        writer.Write(SenderUserName);
        writer.Write(Message);
		var json = PlayFab.SimpleJson.SerializeObject(Timestamp);
        writer.Write(json);
    }

    public override void Deserialize(NetworkReader reader)
    {
        Channel = reader.ReadString();
        SenderUserId = reader.ReadString();
        SenderUserName = reader.ReadString();
        Message = reader.ReadString();
        Timestamp = PlayFab.SimpleJson.DeserializeObject<DateTime>(reader.ReadString());
    }
}

public class CreateChannelMessage : MessageBase
{
    public string ChannelId = Guid.NewGuid().ToString();
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
}
