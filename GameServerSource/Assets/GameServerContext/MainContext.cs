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
    private PlayFabServerStartupCompleteSignal _loadPlayFabDataCompleteSignal;
    private LogSignal _logger;

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
        //Bind start Game Singal that dispatches at launch.
        commandBinder.Bind<StartGameServerSignal>();

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
        //Bind to onComplete.
        _loadPlayFabDataCompleteSignal = injectionBinder.GetInstance<PlayFabServerStartupCompleteSignal>();
        _loadPlayFabDataCompleteSignal.AddListener(OnPlayFabServerStartup);

        //Dispatch Signal to startup
        var loadPlayFabDataSignal = injectionBinder.GetInstance<PlayFabServerStartupSignal>();
        loadPlayFabDataSignal.Dispatch();

    }

    private void OnPlayFabServerStartup(ServerSettingsData settings)
    {
        //TODO: If your using Unity Networking then keep the line below, otherwise comment it out.
        var setupUnityNetworkingSignal = injectionBinder.GetInstance<SetupUnityNetworkingSignal>();
        setupUnityNetworkingSignal.Dispatch();

        //TODO: If your using Photon Networking then keep the line below, otherwise comment it out.
        /* 
        var setupPhotonNetworkingSignal = injectionBinder.GetInstance<SetupPhotonNetworkingSignal>();
        setupPhotonNetworkingSignal.Dispatch();
        */
        injectionBinder.GetInstance<StartGameServerSignal>().Dispatch();
    }
}
public class StartGameServerSignal : Signal { }


