using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatMessageView : MonoBehaviour {

	public Text timestamp;
	public Text message;

	public void SetMessage (string set_message, string set_timestamp)
	{
		message.text = set_message;
		if(set_timestamp!=""){
			timestamp.text = set_timestamp;
		}
	}

}
