using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;

public class UnityNetworkingData : View
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
