using System.Collections.Generic;
using strange.extensions.mediation.impl;

public class ServerSettingsData : View
{
    public string TitleId;
    public ulong GameId;
    public string GameBuildVersion;
    public string GameMode;
    public string ServerHostDomain="localhost";
    public int ServerHostPort = 7777;
    public string ServerHostRegion;
    public string PlayFabApiEndpoint;
    public string TitleSecretKey;
    public string CustomData;
    public bool IsCustomLogFile;
    public string LogFilePath;
    public string OutputFilesDirectory;
    public string BatchMode;
    public List<string> LogEntries;
    public bool CopyLogFiles;
}
