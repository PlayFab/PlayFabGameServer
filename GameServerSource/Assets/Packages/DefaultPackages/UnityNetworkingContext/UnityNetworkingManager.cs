using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class UnityNetworkingManager : StrangePackage
{
    public UnityNetworkingData Settings;
    private UnityNetworkingService _networkService;
    private UnityNetworkingEvents _networkEvents;

    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        _networkService = new UnityNetworkingService();
        _networkEvents = new UnityNetworkingEvents();

        //Bind Settings Object
        injectionBinder.Bind<UnityNetworkingData>().ToValue(Settings).ToSingleton().CrossContext();
        injectionBinder.Bind<UnityNetworkingService>().ToValue(_networkService).ToSingleton().CrossContext();
        injectionBinder.Bind<UnityNetworkingEvents>().ToValue(_networkEvents).ToSingleton().CrossContext();

        //Bind Mediators to Views
        mediationBinder.Bind<UnityNetworkManagerView>().To<UnityNetworkManagerMediator>();
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }
}
