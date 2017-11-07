using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayFabServerManager : StrangePackage
{
    public ServerSettingsData Settings;

    private PlayFabServerEvents _events = new PlayFabServerEvents();
    private PlayFabServerService _service = new PlayFabServerService();

    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        injectionBinder.Bind<ServerSettingsData>().ToValue(Settings).ToSingleton().CrossContext();
        injectionBinder.Bind<PlayFabServerEvents>().ToValue(_events).ToSingleton().CrossContext();
        injectionBinder.Bind<PlayFabServerService>().ToValue(_service).ToSingleton().CrossContext();

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
