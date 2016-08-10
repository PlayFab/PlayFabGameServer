using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class UnityNetworkingManager : StrangePackage
{
    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        //Bind Settings Object
        var settings = Object.FindObjectOfType<UnityNetworkingData>();
        injectionBinder.Bind<UnityNetworkingData>().To(settings).ToSingleton().CrossContext();

        //Bind Mediators to Views
        mediationBinder.Bind<UnityNetworkManagerView>().To<UnityNetworkManagerMediator>();

        //Bind Commands and Signals
        commandBinder.Bind<SetupUnityNetworkingSignal>().To<SetupUnityNetworkingCommand>();
        commandBinder.Bind<SetupUnityNetworkingCompleteSignal>();
        commandBinder.Bind<ClientDisconnectedSignal>();
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }
}
