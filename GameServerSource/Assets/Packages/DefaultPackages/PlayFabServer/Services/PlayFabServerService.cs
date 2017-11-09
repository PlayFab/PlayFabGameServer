using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;

public class PlayFabServerService {
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }
    [Inject] public PlayFabServerEvents ServerEvents { get; set; }
    [Inject] public LogSignal Logger { get; set; }

    public PlayFabServerService(LogSignal logger, PlayFabServerEvents serverEvents, ServerSettingsData settings)
    {
        ServerSettingsData = settings;
        ServerEvents = serverEvents;
        Logger = logger;
    }

    public void PlayFabServerStartup()
    {
        Logger.Dispatch(LoggerTypes.Info, "PlayFab Server Startup Command");

        var commandLineArgs = System.Environment.GetCommandLineArgs();

        foreach (var arg in commandLineArgs)
        {
            var argArray = arg.Split('=');
            if (argArray.Length < 2)
            {
                continue;
            }
            var key = argArray[0].Contains("-") ? argArray[0].Replace("-", "").Trim() : argArray[0].Trim();
            var value = argArray[1].Trim();

            switch (key.ToLower())
            {
                case "game_id":
                    ulong gameId;
                    ulong.TryParse(value, out gameId);
                    ServerSettingsData.GameId = gameId;
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
                    var hostPort = 0;//this is unity networkings default port.
                    int.TryParse(value, out hostPort);
                    hostPort = hostPort > 0 ? hostPort : 7777;
                    ServerSettingsData.ServerHostPort = hostPort;
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
                case "title_id":
                    ServerSettingsData.TitleId = value;
                    break;
            }

            Logger.Dispatch(LoggerTypes.Info, string.Format("GameId:{0} game_build_version:{1} server:{2} port:{3} endoint:{4}",
            ServerSettingsData.GameId, ServerSettingsData.GameBuildVersion, ServerSettingsData.ServerHostDomain,
            ServerSettingsData.ServerHostPort, ServerSettingsData.PlayFabApiEndpoint));

            if (!string.IsNullOrEmpty(ServerSettingsData.TitleSecretKey))
            {
                PlayFabSettings.DeveloperSecretKey = ServerSettingsData.TitleSecretKey;
            }

            if (!string.IsNullOrEmpty(ServerSettingsData.TitleId))
            {
                PlayFabSettings.TitleId = ServerSettingsData.TitleId;
            }

            ServerEvents.ServerStartupComplete(ServerSettingsData);
        }

    }

    public void PlayFabServerStop()
    {
        Logger.Dispatch(LoggerTypes.Info, "Application.Quit Called Immediately After this message.");
        Application.Quit();
    }
}
