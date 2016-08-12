using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public class PlayStreamExampleManager : StrangePackage {

    public override void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder,
        IMediationBinder mediationBinder)
    {
        mediationBinder.Bind<PlayStreamView>().To<PlayStreamMediator>();
    }

}
