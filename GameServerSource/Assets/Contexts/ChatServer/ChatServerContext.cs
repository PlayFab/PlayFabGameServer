using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

public class ChatServerContext : MVCSContext
{
    public ChatServerContextMediator ModuleCtx;

    public ChatServerContext(MonoBehaviour ctxView, bool autoMap) : base(ctxView, autoMap)
    {
        ModuleCtx = (ChatServerContextMediator) ctxView;
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