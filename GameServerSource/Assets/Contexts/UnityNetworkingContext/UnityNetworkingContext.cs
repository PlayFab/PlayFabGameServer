using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

public class UnityNetworkingContext : MVCSContext
{
    public UnityNetworkingMediator GameContext;

    private PlayFabServerStartupCompleteSignal loadPlayFabDataCompleteSignal;

    public UnityNetworkingContext(MonoBehaviour ctxView, bool autoMap)
        : base(ctxView, autoMap)
    {
        GameContext = (UnityNetworkingMediator)ctxView;
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        
        
    }
}
