using UnityEngine;
using System.Collections;

public class ChatServerMessageTypes
{
    public const short ChannelMessage = 700;
    public const short PrivateMessage = 701;
    public const short JoinChannel = 702;
    public const short JoinChannelResponse = 703;
    public const short LeaveChannel = 704;
    public const short CreateChannel = 705;
    public const short CreateChannelResponse = 706;
}
