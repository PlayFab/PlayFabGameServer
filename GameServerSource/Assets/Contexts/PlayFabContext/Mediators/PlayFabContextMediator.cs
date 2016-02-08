using strange.extensions.context.impl;

public class PlayFabContextMediator : ContextView
{
    void Awake () {
        context = new PlayFabContext(this, true);
        context.Start();
    }
}
