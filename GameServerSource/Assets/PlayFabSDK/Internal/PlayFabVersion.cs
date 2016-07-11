
namespace PlayFab.Internal
{
    public class PlayFabVersion
    {
        public static string SdkVersion = "0.0.160711";

        public static string getVersionString()
        {
            return "UnitySDK-" + SdkVersion;
        }
    }
}

