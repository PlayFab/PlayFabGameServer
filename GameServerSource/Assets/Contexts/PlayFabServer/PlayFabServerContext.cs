using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

public class PlayFabServerContext : MVCSContext
{
    public PlayFabServerMediator GameContext;

    public PlayFabServerContext(MonoBehaviour ctxView, bool autoMap)
        : base(ctxView, autoMap)
        {
            GameContext = (PlayFabServerMediator)ctxView;
        }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<PlayFabServerStartupSignal>().CrossContext();
        injectionBinder.Bind<PlayFabServerStartupCompleteSignal>().CrossContext();
    }

}
