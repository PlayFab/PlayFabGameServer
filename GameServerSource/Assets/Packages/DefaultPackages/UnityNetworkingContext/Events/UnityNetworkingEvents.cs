using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnityNetworkingEvents {
    public delegate void ClientConnectedEvent(NetworkMessage netMsg);
    public static event ClientConnectedEvent OnClientConnected;

    public delegate void ClientDisconnectedEvent(int connectionId, string playFabId);
    public static event ClientDisconnectedEvent OnClientDisconnected;

    public delegate void ClientAuthenticationEvent(ClientAuthEventType eventType, NetworkMessage netMsg, string playFabId);
    public static event ClientAuthenticationEvent OnClientAuthenticationTicketReceived;
    public static event ClientAuthenticationEvent OnClientAuthenticationCompleted;


    public void ClientConnected(NetworkMessage netMsg)
    {
        if(OnClientConnected != null)
        {
            OnClientConnected.Invoke(netMsg);
        }
    }

    public void ClientDisconnected(int connectionId, string playFabId)
    {
        if(OnClientDisconnected != null)
        {
            OnClientDisconnected.Invoke(connectionId, playFabId);
        }
    }

    public void ClientAuthenticated(ClientAuthEventType eventType, NetworkMessage netMsg, string playFabId)
    {
        switch (eventType)
        {
            case ClientAuthEventType.TicketReceived:
                if(OnClientAuthenticationTicketReceived != null)
                {
                    OnClientAuthenticationTicketReceived.Invoke(eventType, netMsg, playFabId);
                }
                break;
            case ClientAuthEventType.Validated:
                if(OnClientAuthenticationCompleted != null)
                {
                    OnClientAuthenticationCompleted.Invoke(eventType, netMsg, playFabId);
                }
                break;
        }
    }


}

public enum ClientAuthEventType
{
    TicketReceived,
    Validated
}
