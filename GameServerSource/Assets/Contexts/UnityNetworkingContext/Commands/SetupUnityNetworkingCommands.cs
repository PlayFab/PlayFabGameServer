using UnityEngine;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine.Networking;

public class SetupUnityNetworkingSignal : Signal { }
public class SetupUnityNetworkingCompleteSignal : Signal { }

public class SetupUnityNetworkingCommand : Command
{
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public override void Execute()
    {
        Logger.Dispatch(LoggerTypes.Info, "Setting Up Unity Networking Server");

        //TODO: Create Network Manager, if it is not already in the scene.
        var networkManager = Object.FindObjectOfType<CustomNetworkManager>();
        if (networkManager == null)
        {
            var config = new ConnectionConfig();
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


