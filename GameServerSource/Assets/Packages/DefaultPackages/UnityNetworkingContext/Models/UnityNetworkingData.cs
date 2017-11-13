using System;
using System.Collections.Generic;
using UnityEngine.Networking;

[Serializable]
public class UnityNetworkingData
{
    [Serializable]
    public class UnityNetworkConnection
    {
        public bool IsAuthenticated;
        public string PlayFabId;
        public string LobbyId;
        public int ConnectionId;
        public NetworkConnection Connection;
    }

    public float MaxWaitForConnectSeconds;
    public float MaxWaitForAuthSeconds;
    public int MaxConnections;
    public int ConnectedClients = 0;
    public CustomNetworkManager Manager;
    public NetworkClient Client;
    public List<UnityNetworkConnection> Connections;
}
