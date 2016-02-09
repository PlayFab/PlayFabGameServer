using System;
using System.IO;
using UnityEngine;
using strange.extensions.signal.impl;
using strange.extensions.command.impl;

public enum LoggerTypes
{
    Info,
    Warning,
    Error
}

public class LogSignal : Signal<LoggerTypes, object> { }

public class LogSignalCommand : Command
{
    [Inject] public LoggerTypes LoggerType { get; set; } 
    [Inject] public object Message { get; set; }
    [Inject] public ServerSettingsData ServerSettingsData { get; set; }

    public override void Execute()
    {
        switch (LoggerType)
        {
            case LoggerTypes.Info:
                Debug.LogFormat("Info: {0}", Message);
                ServerSettingsData.LogEntries.Add(string.Format("Info: {0}", Message ));
                break;
            case LoggerTypes.Warning:
                Debug.LogWarningFormat("Warning: {0}", Message);
                ServerSettingsData.LogEntries.Add(string.Format("Warning: {0}", Message));
                break;
            case LoggerTypes.Error:
                var e = (Exception) Message;
                Debug.LogErrorFormat("Error: {0}", e.Message );
                Debug.LogErrorFormat("Error: {0}", e.StackTrace);
                ServerSettingsData.LogEntries.Add(string.Format("Error: {0}", e.Message));
                ServerSettingsData.LogEntries.Add(string.Format("Error-Stack: {0}", e.StackTrace));
                break;
        }

        if (ServerSettingsData.IsCustomLogFile)
        { 
            var logFilePath = ServerSettingsData.LogFilePath;
            var outputDirectory = ServerSettingsData.OutputFilesDirectory;
            if (string.IsNullOrEmpty(logFilePath))
            {
                return;
            }

            if (!File.Exists(logFilePath))
            {
                File.WriteAllLines(logFilePath, ServerSettingsData.LogEntries.ToArray());
            }
            else
            {
                foreach (var strOut in ServerSettingsData.LogEntries)
                {
                    File.AppendAllText(logFilePath, strOut);
                }
            }
        }
        ServerSettingsData.LogEntries.Clear();
    }
}



