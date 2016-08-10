using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;

public interface iStrangePackage
{
    void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder, IMediationBinder mediationBinder);
    void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder, IMediationBinder mediationBinder);
    void Launch(ICrossContextInjectionBinder injectionBinder);
}
