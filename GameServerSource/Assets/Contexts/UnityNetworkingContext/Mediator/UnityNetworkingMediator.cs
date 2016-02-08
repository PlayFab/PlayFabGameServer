
using strange.extensions.context.impl;

public class UnityNetworkingMediator : ContextView {
	void Awake () {
	    context = new UnityNetworkingContext(this,true);
	    context.Start();
	}
}
