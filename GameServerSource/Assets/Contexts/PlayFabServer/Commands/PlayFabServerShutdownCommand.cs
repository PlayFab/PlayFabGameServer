using UnityEngine;
using System.IO;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

public class PlayFabServerShutdownSignal : Signal { }
public class PlayFabServerShutdownCommand : Command {

    public override void Execute()
    {
        Debug.Log("Application.Quit Called Immediately After this message.");
        Application.Quit();
    }
}
