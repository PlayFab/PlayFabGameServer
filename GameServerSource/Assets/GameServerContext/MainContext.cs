using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.signal.impl;
using System.Linq;

public class MainContext : MVCSContext
{
    public MainContextView MainCtx;
    private LogSignal _logger;
    private PlayFabServerService _serverService;

    public MainContext(MonoBehaviour ctxView, bool autoMap)
        : base(ctxView, autoMap)
    {
        MainCtx = (MainContextView)ctxView;
        MainCtx.Packages = MainCtx.GetComponentsInChildren<StrangePackage>().ToList();
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

        injectionBinder.Bind<ICrossContextInjectionBinder>().ToValue(injectionBinder);
    }

    protected override void mapBindings()
    {
        foreach (var pack in MainCtx.Packages)
        {
            pack.MapBindings(commandBinder, injectionBinder, mediationBinder);
        }
    }

    protected override void postBindings()
    {
        foreach (var pack in MainCtx.Packages)
        {
            pack.PostBindings(commandBinder, injectionBinder, mediationBinder);
        }
    }

    public override void Launch()
    {
        _logger = injectionBinder.GetInstance<LogSignal>();
        _logger.Dispatch(LoggerTypes.Info, "Launch from MainGameServer Context.");

        foreach (var pack in MainCtx.Packages)
        {
            pack.Launch(injectionBinder);
        }

        PlayFabServerEvents.OnServerStartupComplete += OnPlayFabServerStartup;

        //startup server
        _serverService = injectionBinder.GetInstance<PlayFabServerService>();
        _serverService.PlayFabServerStartup();
    }
    
    private void OnPlayFabServerStartup(ServerSettingsData settings)
    {
        //TODO: Support other networking packages such as Photon, DarkRift, MQTT
        if (settings.NetworkType == NetworkingType.UnityNetworking)
        {
            var networkingService = injectionBinder.GetInstance<UnityNetworkingService>();
            networkingService.SetupNetworking();
        }

        injectionBinder.GetInstance<PlayFabServerEvents>().GameServerStarted();
    }
}



