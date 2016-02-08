using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class UnityNetworkingBindingsFactory  {

    public static void Create(ICommandBinder commandBinder, IInjectionBinder injectionBinder, IMediationBinder mediationBinder )
    {
        //Bind Settings Object
        var settings = Object.FindObjectOfType<UnityNetworkingData>();
        injectionBinder.Bind<UnityNetworkingData>().To(settings).ToSingleton().CrossContext();

        //Bind Mediators to Views
        mediationBinder.Bind<UnityNetworkManagerView>().To<UnityNetworkManagerMediator>();

        //Bind Commands and Signals
        commandBinder.Bind<SetupUnityNetworkingSignal>().To<SetupUnityNetworkingCommand>();
        commandBinder.Bind<SetupUnityNetworkingCompleteSignal>();
    }
}
