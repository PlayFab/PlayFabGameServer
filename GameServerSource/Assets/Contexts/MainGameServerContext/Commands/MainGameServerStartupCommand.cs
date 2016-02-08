using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;


public class MainGameServerStartupSignal : Signal { }
public class MainGameServerStartupCompleteSignal : Signal { }

public class MainGameServerStartupCommand : Command {
    [Inject] public MainGameServerStartupCompleteSignal OnStartupComplete { get; set; }
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    
    /// <summary>
    /// Note that if you are not using Unity Networking then this needs to be disabled.
    /// </summary>
    [Inject] public UnityNetworkingData UnityNetworkingData { get; set; }

    public override void Execute()
    {
        //StartMessageReciever if you are using UnityNetworking



        //TODO: Do some custom Setup Stuff here that is specific to your server
        /*
         * This could be stuff like setting up data, etc.. etc.. 
         * Notice that the ServerSettingsData is available for you to use here
         */

        OnStartupComplete.Dispatch();
    }
}
