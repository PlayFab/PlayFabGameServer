using strange.extensions.command.api;
using strange.extensions.injector.api;
using UnityEngine;

public class PlayFabServerMapFactory  {

    public static void Create(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder)
    {
        var settings = Object.FindObjectOfType<ServerSettingsData>();
        injectionBinder.Bind<ServerSettingsData>().To(settings).ToSingleton().CrossContext();

        commandBinder.Bind<PlayFabServerStartupSignal>().To<PlayFabServerStartupCommand>();
        commandBinder.Bind<PlayFabServerStartupCompleteSignal>();
        commandBinder.Bind<PlayFabServerShutdownSignal>();
        commandBinder.Bind<PlayFabServerShutdownSignal>().To<PlayFabServerShutdownCommand>();
        commandBinder.Bind<LogSignal>().To<LogSignalCommand>();
    }

}
