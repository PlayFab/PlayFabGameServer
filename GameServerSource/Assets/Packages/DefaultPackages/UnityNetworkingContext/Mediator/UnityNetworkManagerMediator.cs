using System;
using System.Collections;
using PlayFab.ServerModels;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using PlayFab;

public class UnityNetworkManagerMediator : EventMediator {
    [Inject] public UnityNetworkManagerView View { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public UnityNetworkingEvents UnityNetworkingEvents { get; set; }
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    [Inject] public PlayFabServerService ServerService { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public class AuthTicketMessage : MessageBase
    {
        public string PlayFabId;
        public string AuthTicket;
        public bool IsLocal;
    }

    public override void OnRegister()
    {
        NetworkServer.RegisterHandler(MsgType.Connect, OnServerConnect);
        NetworkServer.RegisterHandler(MsgType.Disconnect, OnServerDisconnect);
        NetworkServer.RegisterHandler(MsgType.Error, OnServerError);
        NetworkServer.RegisterHandler(200, OnAuthenticateConnection);
        StartCoroutine(CheckForConnectionsOrClose());
    }

    IEnumerator CheckForConnectionsOrClose()
    {
        yield return new WaitForSeconds(UnityNetworkingData.MaxWaitForConnectSeconds);
        if (UnityNetworkingData.ConnectedClients == 0)
        {
            Logger.Dispatch(LoggerTypes.Info, "No Connections were made, shutting down.");
            ServerService.PlayFabServerStop();
        }
    }

    IEnumerator CheckForUnauthenticatedClients(int connectionId)
    {
        yield return new WaitForSeconds(UnityNetworkingData.MaxWaitForAuthSeconds);
        var uconn = UnityNetworkingData.Connections.Find(c => c.ConnectionId == connectionId);
        if (uconn != null)
        {
            if (!uconn.IsAuthenticated)
            {
                uconn.Connection.Disconnect();
            }
        }
    }

    private void OnAuthenticateConnection(NetworkMessage netMsg)
    {
        var uconn = UnityNetworkingData.Connections.Find(c => c.ConnectionId == netMsg.conn.connectionId);
        if (uconn != null)
        {
            var message = netMsg.ReadMessage<AuthTicketMessage>();
            uconn.PlayFabId = message.PlayFabId;
            UnityNetworkingEvents.ClientAuthenticated(ClientAuthEventType.TicketReceived, netMsg, message.PlayFabId);
            Logger.Dispatch(LoggerTypes.Info, string.Format("Auth Received: PlayFabId:{0} AuthTicket:{1}", message.PlayFabId,message.AuthTicket));

            if (!message.IsLocal)
            {
                PlayFabServerAPI.RedeemMatchmakerTicket(new RedeemMatchmakerTicketRequest(){
                    Ticket = message.AuthTicket,
                    LobbyId = ServerSettingsData.GameId.ToString()
                }, OnAuthUserResponse, null);
            }
            else
            {
                PlayFabServerAPI.AuthenticateSessionTicket(new AuthenticateSessionTicketRequest(){
                    SessionTicket = message.AuthTicket
                }, OnAuthLocalUserResponse, null);
            }
        }
    }

    private void OnAuthLocalUserResponse(AuthenticateSessionTicketResult response)
    {
        Logger.Dispatch(LoggerTypes.Info, string.Format("PlayFab Says AuthTicket isValid:{0}", true));
        var uconn = UnityNetworkingData.Connections.Find(c => c.PlayFabId == response.UserInfo.PlayFabId);
        if (uconn != null)
        {
            uconn.IsAuthenticated = true;
            uconn.Connection.Send(201, new StringMessage()
            {
                value = "Client Authenticated Successfully"
            });
            UnityNetworkingEvents.ClientAuthenticated(ClientAuthEventType.Validated, null, response.UserInfo.PlayFabId);
        }
    }

    private void OnAuthUserResponse(RedeemMatchmakerTicketResult response)
    {
        Logger.Dispatch(LoggerTypes.Info, string.Format("PlayFab Says AuthTicket isValid:{0}",response.TicketIsValid));
        var uconn = UnityNetworkingData.Connections.Find(c => c.PlayFabId == response.UserInfo.PlayFabId);
        if (uconn != null)
        {
            uconn.IsAuthenticated = response.TicketIsValid;
            uconn.Connection.Send(201, new StringMessage()
            {
                value = "Client Authenticated Successfully"
            });
            UnityNetworkingEvents.ClientAuthenticated(ClientAuthEventType.Validated, null, response.UserInfo.PlayFabId);
        }
    }

    // called when a client connects 
    private void OnServerConnect(NetworkMessage netMsg)
    {
        
        UnityNetworkingData.ConnectedClients++;
        UnityNetworkingData.Connections.Add(new UnityNetworkingData.UnityNetworkConnection()
        {
            Connection = netMsg.conn,
            ConnectionId = netMsg.conn.connectionId,
            LobbyId = ServerSettingsData.GameId.ToString(),
            IsAuthenticated = false
        });

        //Security:
        //Give them 30 seconds to authenticate or close the connection.
        StartCoroutine(CheckForUnauthenticatedClients(netMsg.conn.connectionId));

        UnityNetworkingEvents.ClientConnected(netMsg);

        Logger.Dispatch(LoggerTypes.Info, "A Unity Client Connected");
    }

    // called when a client disconnects
    private void OnServerDisconnect(NetworkMessage netMsg)
    {
        if (UnityNetworkingData.ConnectedClients - 1 >= 0)
        {
            UnityNetworkingData.ConnectedClients--;
        }

        if (UnityNetworkingData.ConnectedClients == 0)
        {
            StartCoroutine(CheckForConnectionsOrClose());    
        }

        var connection = UnityNetworkingData.Connections.Find(c => c.ConnectionId == netMsg.conn.connectionId);
        if (connection != null)
        {
            if (connection.IsAuthenticated && ServerSettingsData.GameId > 0)
            {
                PlayFabServerAPI.NotifyMatchmakerPlayerLeft(new NotifyMatchmakerPlayerLeftRequest(){
                    PlayFabId = connection.PlayFabId,
                    LobbyId = ServerSettingsData.GameId.ToString() 
                }, (playerLeftResponse) =>
                {
                    UnityNetworkingEvents.ClientDisconnected(connection.ConnectionId, connection.PlayFabId);
                    Logger.Dispatch(LoggerTypes.Info,string.Format("Player Has Left:{0}",connection.PlayFabId));
                    UnityNetworkingData.Connections.Remove(connection);
                }, null);
            }
            else
            {
                UnityNetworkingEvents.ClientDisconnected(connection.ConnectionId, connection.PlayFabId);
                UnityNetworkingData.Connections.Remove(connection);
            }
        }
        else
        {
            UnityNetworkingEvents.ClientDisconnected(netMsg.conn.connectionId, null);
        }

        Logger.Dispatch(LoggerTypes.Info, "A Unity Client Disconnected");
    }

    // called when a network error occurs
    public void OnServerError(NetworkMessage netMsg)
    {
        try
        {
            var error = netMsg.ReadMessage<ErrorMessage>();
            if (error != null)
            {
                Logger.Dispatch(LoggerTypes.Info,
                    string.Format("Unity Network Connection Status: code - {0}", error.errorCode));
            }
        }
        catch (Exception)
        {
            Logger.Dispatch(LoggerTypes.Info,"Unity Network Connection Status, but we could not get the reason, check the Unity Logs for more info.");
        }
        
        //TODO: Figure out why we would want to terminate the server if there was a network error
        //ServerService.PlayFabServerStop();
    }


}
