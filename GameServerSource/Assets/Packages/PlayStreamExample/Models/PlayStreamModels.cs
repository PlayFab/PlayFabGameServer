using System;
using UnityEngine.Networking;

public static class PlayStreamMsgTypes
{
    public static short RegisterForEvents = 300;
    public static short OnPlayStreamEventReceived = 301;
    public static short RequestForFriendList = 302;
    public static short OnSendFriendsList = 303;
}

public class RegisterForEventsMessage : MessageBase
{
    public PlayStreamSubscription Subscription;
}

public class PlayStreamEventMessage : MessageBase
{
    //metadata for easier deserialization for clients
    public string EventName;
    public string EntityType;
    public string EventNamespace;

    public string EventData;
}

public class AskForFriendListMessage : MessageBase
{
    public string PlayfabId;
}

public class FriendListMessage : MessageBase
{
    public string[] PlayfabIds;
}

[Serializable]
public class PlayStreamSubscription
{
    public string PlayFabId;

    public string EventName;
}
