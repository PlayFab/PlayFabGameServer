using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayFabServerManager : StrangePackage
{
    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        var settings = Object.FindObjectOfType<ServerSettingsData>();
        injectionBinder.Bind<ServerSettingsData>().To(settings).ToSingleton().CrossContext();

        injectionBinder.Bind<PlayFabServerStartupSignal>();
        injectionBinder.Bind<PlayFabServerStartupCompleteSignal>();

        commandBinder.Bind<PlayFabServerStartupSignal>().To<PlayFabServerStartupCommand>();
        commandBinder.Bind<PlayFabServerStartupCompleteSignal>();
        commandBinder.Bind<PlayFabServerShutdownSignal>();
        commandBinder.Bind<PlayFabServerShutdownSignal>().To<PlayFabServerShutdownCommand>();
        commandBinder.Bind<LogSignal>().To<LogSignalCommand>();

    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }
}
