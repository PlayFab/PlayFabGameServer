using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatChannel
{
    public string ChannelId;
    public List<ChatChannelMember> Members = new List<ChatChannelMember>();
    public List<ChatChannelHistoryItem> History = new List<ChatChannelHistoryItem>();
    public bool IsUserCreated;
}

public class ChatChannelMember
{
    public string MemberId;
    public string MemberName;
}

public class ChatChannelHistoryItem
{
    public string MemberId;
    public string Message;
}