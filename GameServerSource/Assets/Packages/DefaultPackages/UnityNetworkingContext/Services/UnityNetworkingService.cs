using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UnityNetworkingService
{
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public void SetupNetworking()
    {
        Logger.Dispatch(LoggerTypes.Info, "Setting Up Unity Networking Server");

        var networkManager = Object.FindObjectOfType<CustomNetworkManager>();
        if (networkManager == null)
        {
            // var config = new ConnectionConfig();
            //TODO: Set some config properties if you want.

            //Create one.
            var networkManagerGameObject = new GameObject("UnityNetworkManager");
            networkManager = networkManagerGameObject.AddComponent<CustomNetworkManager>();
            networkManagerGameObject.AddComponent<NetworkManagerHUD>();
            networkManagerGameObject.AddComponent<UnityNetworkManagerView>();
            networkManager.networkAddress = ServerSettingsData.ServerHostDomain;
            networkManager.networkPort = ServerSettingsData.ServerHostPort;
            networkManager.StartServer(); //pass a config here if you created one.
        }
        else
        {
            networkManager.StartServer();

        }

        UnityNetworkingData.Manager = networkManager;
        UnityNetworkingData.Client = networkManager.client;
    }

}
