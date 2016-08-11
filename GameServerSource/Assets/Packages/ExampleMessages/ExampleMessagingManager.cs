using UnityEngine;
using System.Collections;
using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class ExampleMessagingManager : StrangePackage {

    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        mediationBinder.Bind<MsgReceiverExampleView>().To<MsgReceiverExampleMediator>();
        mediationBinder.Bind<NewPromoExampleView>().To<NewPromoExampleMediator>();
    }

    public override void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        
    }

}
