using System.Diagnostics;
using UnityEngine;
using System.IO;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;

public class PlayFabServerShutdownSignal : Signal { }
public class PlayFabServerShutdownCommand : Command {
    [Inject] ServerSettingsData ServerSettingsData { get; set; }
    public override void Execute()
    {
        var logFilePath = ServerSettingsData.LogFilePath;
        var outputDirectory = ServerSettingsData.OutputFilesDirectory;

        /*
        if (string.IsNullOrEmpty(logFilePath))
        {
            return;
        }
        File.WriteAllLines(logFilePath, ServerSettingsData.LogEntries.ToArray());
        */

        if (!string.IsNullOrEmpty(outputDirectory))
        {
            File.Copy(logFilePath, outputDirectory + Path.GetFileName(logFilePath));
#if UNITY_STANDALONE_OSX 
            var filePath = "~/Library/Logs/Unity/Player.log";
            File.Copy(filePath, outputDirectory + Path.GetFileName(filePath));
#elif UNITY_STANDALONE_WIN
            var filePath = string.Format("{0}\\{1}", Application.dataPath, "output_log.txt");
            File.Copy(filePath, outputDirectory + Path.GetFileName(filePath));
#elif UNITY_STANDALONE_LINUX
            var filePath = string.Format("~/.config/unity3d/{0}/{1}/Player.log",Application.companyName,Application.productName);
            File.Copy(filePath, outputDirectory + Path.GetFileName(filePath));
#endif
        }
        Application.Quit();
    }
}
