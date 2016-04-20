using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class ChatChannel
{
    public string ChannelId;
    public List<ChatChannelMember> Members = new List<ChatChannelMember>();
    public List<ChatChannelHistoryItem> History = new List<ChatChannelHistoryItem>();
    public bool IsInviteOnly;
}

[Serializable]
public class ChatChannelMember
{
    public string MemberId;
    public string MemberName;
}

[Serializable]
public class ChatChannelHistoryItem
{
    public string MemberId;
    public string Message;
}