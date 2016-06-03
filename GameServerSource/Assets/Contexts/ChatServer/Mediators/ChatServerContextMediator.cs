using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class ChatServerContextMediator : ContextView
{

	void Awake () {
        context = new ChatServerContext(this,true);
        context.Start();
    }
	
}
