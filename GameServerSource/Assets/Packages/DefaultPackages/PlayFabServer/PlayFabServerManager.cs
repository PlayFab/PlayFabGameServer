using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayFabServerManager : StrangePackage
{
    public ServerSettingsData Settings;

    private PlayFabServerEvents _events;
    private PlayFabServerService _service;

    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        commandBinder.Bind<LogSignal>().To<LogSignalCommand>();
        var _logger = injectionBinder.GetInstance<LogSignal>();

        injectionBinder.Bind<ServerSettingsData>().ToValue(Settings).ToSingleton().CrossContext();

        _events = new PlayFabServerEvents();
        injectionBinder.Bind<PlayFabServerEvents>().ToValue(_events).ToSingleton().CrossContext();

        _service = new PlayFabServerService(_logger, _events, Settings);
        injectionBinder.Bind<PlayFabServerService>().ToValue(_service).ToSingleton().CrossContext();

        
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }
}
