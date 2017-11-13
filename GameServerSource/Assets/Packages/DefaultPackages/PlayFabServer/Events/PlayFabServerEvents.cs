using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabServerEvents {
    public delegate void ServerSetupCompleteEvent(ServerSettingsData serverSettingsData);
    public static event ServerSetupCompleteEvent OnServerStartupComplete;

    public delegate void StartGameServerEvent();
    public static event StartGameServerEvent OnGameServerStarted;

    public void ServerStartupComplete(ServerSettingsData data)
    {
        if(OnServerStartupComplete != null)
        OnServerStartupComplete.Invoke(data);
    }

    public void GameServerStarted()
    {
        if (OnGameServerStarted != null)
            OnGameServerStarted.Invoke();
    }

}
