using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BantsResponseButton : MonoBehaviour {

	public Text message_text;

	int progress;
	new string name;
	string response_message;

	public void SetupResponse (string message, string chatter_name, int set_progress)
	{
		message_text.text = response_message = message;
		progress = set_progress;
		name = chatter_name;
	}

	/*public void ResponseClicked ()
	{
		References.instance.bants_app_logic.ResponseClicked (response_message, name, progress);
	}*/

}
