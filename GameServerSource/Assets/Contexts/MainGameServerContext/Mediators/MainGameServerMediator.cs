using strange.extensions.context.impl;

public class MainGameServerMediator : ContextView {

	// Use this for initialization
	void Awake () {
        context = new MainGameServerContext(this, true);
        context.Start();
        DontDestroyOnLoad(gameObject);
	}

}
