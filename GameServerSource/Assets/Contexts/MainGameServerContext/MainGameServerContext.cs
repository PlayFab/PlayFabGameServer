using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;

public class MainGameServerContext : MVCSContext
{
    public MainGameServerMediator GameContext;

    private PlayFabServerStartupCompleteSignal _loadPlayFabDataCompleteSignal;
    private LogSignal _logger;

    #region DON't TOUCH THIS, IT IS PART OF STRANGEIOC AND IT SHOULDN'T BE MODIFIED.
    public MainGameServerContext(MonoBehaviour ctxView, bool autoMap)
        : base(ctxView, autoMap)
    {
        GameContext = (MainGameServerMediator)ctxView;
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
    #endregion

    protected override void mapBindings()
    {
        #region DO NOT TOUCH THESE ARE CORE 
        commandBinder.Bind<MainGameServerStartupSignal>().To<MainGameServerStartupCommand>();
        commandBinder.Bind<MainGameServerStartupCompleteSignal>();

        //LOADING MAP FACTORIES        
        PlayFabServerMapFactory.Create(commandBinder,injectionBinder);
        PlayFabBindingsFactory.Create(commandBinder);
        #endregion

        #region CHOOSE YOUR NETWORKING TYPE (DEFAULT: UnityNetworking)
        //TODO: If your using Unity Networking then keep the line below, otherwise comment it out.
        UnityNetworkingBindingsFactory.Create(commandBinder, injectionBinder, mediationBinder);

        //TODO: If your using Photon Networking then keep the line below, otherwise comment it out.
        //PhotonNetworkingBindingsFactory.Create(commandBinder, injectionBinder);
        #endregion
        
        /* LOAD YOUR BINDINGS HERE */

        //This is an example of recieving a message and sending a result back to the Client.
        mediationBinder.Bind<MsgReceiverExampleView>().To<MsgReceiverExampleMediator>();
        mediationBinder.Bind<NewPromoExampleView>().To<NewPromoExampleMediator>();
        /*END LOAD YOUR BINDINGS */
    }

    public override void Launch()
    {
        #region GAMER SERVER STARTUP CODE ( You don't need to touch this )
        _logger = injectionBinder.GetInstance<LogSignal>();
        _logger.Dispatch(LoggerTypes.Info,"Launch from MainGameServer Context.");
        
        //Bind to onComplete.
        _loadPlayFabDataCompleteSignal = injectionBinder.GetInstance<PlayFabServerStartupCompleteSignal>();
        _loadPlayFabDataCompleteSignal.AddListener(OnPlayFabServerStartup);

        //Dispatch Signal to startup
        var loadPlayFabDataSignal = injectionBinder.GetInstance<PlayFabServerStartupSignal>();
        loadPlayFabDataSignal.Dispatch();     
        #endregion
    }

    #region GAMER SERVER STARTUP HANDLER (You don't need to touch this either)
    private void OnPlayFabServerStartup(ServerSettingsData settings)
    {
        _logger.Dispatch(LoggerTypes.Info, "PlayFab Server Has been started");
        _loadPlayFabDataCompleteSignal.RemoveListener(OnPlayFabServerStartup);

        var startGameServerSignal = injectionBinder.GetInstance<MainGameServerStartupSignal>();
        var startGameServerCompleteSignal = injectionBinder.GetInstance<MainGameServerStartupCompleteSignal>();
        startGameServerCompleteSignal.AddListener(OnStartMainGameServerComplete);
        startGameServerSignal.Dispatch();
    }
    #endregion


    /// <summary>
    /// This is what dispatches an event and tells the Networking Server to listen to a port.
    /// By default it is the Unity Networking Server, but you can replace it here and have photon dispatch instead
    /// if you have the photon context installed.
    /// </summary>
    private void OnStartMainGameServerComplete()
    {
        //TODO: If your using Unity Networking then keep the line below, otherwise comment it out.
        var setupUnityNetworkingSignal = injectionBinder.GetInstance<SetupUnityNetworkingSignal>();
        setupUnityNetworkingSignal.Dispatch();

        //TODO: If your using Photon Networking then keep the line below, otherwise comment it out.
        /* 
        var setupPhotonNetworkingSignal = injectionBinder.GetInstance<SetupPhotonNetworkingSignal>();
        setupPhotonNetworkingSignal.Dispatch();
        */
    }

}
