using strange.extensions.context.impl;

public class PlayFabServerMediator : ContextView {
    public void Awake()
    {
        context = new PlayFabServerContext(this, true);
        context.Start();
    }

}
