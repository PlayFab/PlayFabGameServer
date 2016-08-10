using strange.extensions.command.api;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;
using UnityEngine;

public abstract class StrangePackage : MonoBehaviour, iStrangePackage
{
    public virtual void MapBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder, IMediationBinder mediationBinder) { }
    public virtual void PostBindings(ICommandBinder commandBinder, ICrossContextInjectionBinder injectionBinder, IMediationBinder mediationBinder) { }
    public virtual void Launch(ICrossContextInjectionBinder injectionBinder) { }
}