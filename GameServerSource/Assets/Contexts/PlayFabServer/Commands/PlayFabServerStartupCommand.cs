using System;
using UnityEngine;
using System.Collections;
using PlayFab;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

public class PlayFabServerStartupSignal : Signal { }
public class PlayFabServerStartupCompleteSignal : Signal<ServerSettingsData> { }

/// <summary>
/// This command, parses the command line args that are passed to the gameserver EXE file from PlayFab 
/// </summary>
public class PlayFabServerStartupCommand : Command {
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    [Inject] public PlayFabServerStartupCompleteSignal OnCompleteSignal { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public override void Execute()
    {
        Logger.Dispatch(LoggerTypes.Info,"PlayFab Server Startup Command");

        var commandLineArgs = System.Environment.GetCommandLineArgs();

        foreach (var arg in commandLineArgs)
        {
            var argArray = arg.Split('=');
            if (argArray.Length < 2)
            {
                continue; 
            }
            var key = argArray[0].Contains("-") ? argArray[0].Replace("-","").Trim() : argArray[0].Trim();
            var value = argArray[1].Trim();

            switch (key.ToLower())
            {
                case "game_id":
                    ServerSettingsData.GameId = long.Parse(value);
                    break;
                case "game_build_version":
                    ServerSettingsData.GameBuildVersion = value;
                    break;
                case "game_mode":
                    ServerSettingsData.GameMode = value;
                    break;
                case "server_host_domain":
                    ServerSettingsData.ServerHostDomain = value;
                    break;
                case "server_host_port":
                    ServerSettingsData.ServerHostPort = int.Parse(value) != 0 ? int.Parse(value) : 7777; //this is unity networkings default port.
                    break;
                case "server_host_region":
                    ServerSettingsData.ServerHostRegion = value;
                    break;
                case "playfab_api_endpoint":
                    ServerSettingsData.PlayFabApiEndpoint = value;
                    break;
                case "title_secret_key":
                    ServerSettingsData.TitleSecretKey = value;
                    break;
                case "custom_data":
                    ServerSettingsData.CustomData = value;
                    break;
                case "log_file_path":
                    ServerSettingsData.LogFilePath = value;
                    break;
                case "output_files_directory_path":
                    ServerSettingsData.OutputFilesDirectory = value;
                    break;
            }
        }

        Logger.Dispatch(LoggerTypes.Info,string.Format("GameId:{0} game_build_version:{1} server:{2} port:{3} endoint:{4}",
            ServerSettingsData.GameId, ServerSettingsData.GameBuildVersion, ServerSettingsData.ServerHostDomain,
            ServerSettingsData.ServerHostPort, ServerSettingsData.PlayFabApiEndpoint));

        if(!string.IsNullOrEmpty(ServerSettingsData.TitleSecretKey))
        {
            PlayFabSettings.DeveloperSecretKey = ServerSettingsData.TitleSecretKey;
        }

        if (!string.IsNullOrEmpty(ServerSettingsData.TitleId))
        {
            PlayFabSettings.TitleId = ServerSettingsData.TitleId;
        }

        //Dispatch that the server settings have been completed.
        OnCompleteSignal.Dispatch(ServerSettingsData);
    }
}
