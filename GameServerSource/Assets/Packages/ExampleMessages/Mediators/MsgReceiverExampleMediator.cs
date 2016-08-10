using UnityEngine;
using System.Collections;
using PlayFab.ServerModels;
using strange.extensions.mediation.impl;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MsgReceiverExampleMediator : Mediator {
    [Inject] public MsgReceiverExampleView View { get; set; }
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public GetTitleDataSignal GetTitleDataSignal { get; set; }
    [Inject] public GetTitleDataResponseSignal GetTitleDataResponseSignal { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public override void OnRegister()
    {
        NetworkServer.RegisterHandler(1001, OnGetTitleData);
    }

    private void OnGetTitleData(NetworkMessage netMsg)
    {
        //Get the active matched connection
        var uconn = UnityNetworkingData.Connections.Find(c => c.ConnectionId == netMsg.conn.connectionId);

        //Make sure that we have an authenticated connection.
        if (uconn == null || !uconn.IsAuthenticated)
        {
            return;
        }
        GetTitleDataResponseSignal.AddOnce((result) =>
        {
            OnGetTitleData(uconn.Connection,result);
        });
        GetTitleDataSignal.Dispatch(new GetTitleDataRequest());
    }

    private void OnGetTitleData(NetworkConnection connection, GetTitleDataResult result)
    {
        //Do something cool with title data and Return back to the client.
        var output = string.Format("Recieved {0} Title Data Keys", result.Data.Keys.Count);
        Logger.Dispatch(LoggerTypes.Info, output);
        connection.Send(1002, new StringMessage()
        {
            value = string.Format(output)
        });
    }



}
