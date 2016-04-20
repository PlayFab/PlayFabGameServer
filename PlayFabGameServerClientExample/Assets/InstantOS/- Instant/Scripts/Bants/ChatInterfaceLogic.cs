using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Linq;
using System;

public class ChannelTransformConnection {
	public string ChannelId;
	public Transform ChatContentTransform;
}

public class ChatInterfaceLogic : MonoBehaviour {

	public Animator contact_list;
	public Animator conversation_screen;

	public Transform contact_list_transform;
	public Transform chat_transform;
	public GameObject received_message_header;
	public GameObject received_message_prefab;
	public GameObject sent_message_header;
	public GameObject sent_message_prefab;

	private List<GameObject> response_buttons = new List<GameObject>();
	private List<GameObject> contact_buttons = new List<GameObject>();

	/*public void BackToContactList ()
	{
		RefreshContactList ();

		StopCoroutine ("EnterMessageThread");
		//Clear chats and responses:
		foreach (Transform child in chat_transform)
		{
			Destroy (child.gameObject);
		}
		foreach (Transform child in response_transform)
		{
			Destroy (child.gameObject);
		}

		InstantOS.instance.screen_manager.OpenPanel (contact_list);
	}

	public void RefreshContactList ()
	{
		for(int i=0;i<contact_buttons.Count;i++){
			Destroy (contact_buttons[i]);
		}
		contact_buttons.Clear ();
		for(int i=0;i<PlayerData.instance.bants_contacts.Count;i++){
			GameObject contact_button = Instantiate (contact_button_prefab);
			contact_button.transform.SetParent (contact_list_transform, false);
			contact_button.GetComponent<BantsContactButton>().SetContact (PlayerData.instance.bants_contacts[i].name);
			contact_buttons.Add (contact_button);
		}
	}
	public void ContactClicked (string name)
	{
		InstantOS.instance.screen_manager.OpenPanel (conversation_screen);
		current_contact = PlayerData.instance.bants_contacts.Find(c => c.name == name);
		if(current_contact!=null){
			EnterChat (name, current_contact.progress);
		}
		else{
			Debug.Log ("Contact not found! "+name);
		}
	}

//	private BantsContact current_contact;
	private int current_progress;
//	private BantsConvo current_convo;
//	private BantsPage current_page;
	private int current_message;


	public void EnterChat (string name, int progress)
	{
		Debug.Log("EnterChat "+name +" "+progress);

		active_chat_contact_button.SetContact (name);
		current_contact.progress = progress; //store our progress
		current_progress = progress;
		current_message = 0;
		for(int i=0;i<response_buttons.Count;i++){Destroy(response_buttons[i]);}
		response_buttons.Clear ();

		if(current_convo != null){
			if(current_convo.pages[0].name == name){ //We're already in this conversation with this person, so just grab the page.
				current_page = current_convo.pages.Find(c => c.progress == current_progress);
				if(current_page != null){
					EnterPage ();
					return;
				}
			}
		}

		//If the page we're looking for wasn't found, look it up:
		current_convo = BantsLoader.instance.LookForConvo(name, progress);

		if(current_convo != null) {
			current_page = current_convo.pages.Find(c => c.progress == current_progress);
			EnterPage ();
		}
		else {
			Debug.Log("no convo found");
		}
	}

	void EnterPage ()
	{
		if(current_page==null){
			Debug.Log("current_page is null");
			return;
		}

		GameObject new_header_gameobject = Instantiate (received_message_header) as GameObject;
		new_header_gameobject.GetComponent<TextLink>().text.text = current_page.name;
		new_header_gameobject.transform.SetParent (chat_transform, false);

		current_message = 0;
		EnterMessage ();
	}

	void EnterMessage()
	{
		StartCoroutine ("EnterMessageThread");
	}

	IEnumerator EnterMessageThread ()
	{
		if (current_page.messages.Count <= current_message){
			yield break;
		}

		BantsMessage message = current_page.messages[current_message];

		if(message.type == BantsType.Action){
			yield return new WaitForSeconds (1.1f);
			StorylineLogic.instance.SendMessage(message.message);
		}
		else if(message.type == BantsType.Contact){

			PlayerData.instance.bants_contacts.Add (new BantsContact(){
				name = message.message,
				progress = 0
			});

		}
		else{ //Standard Message
			yield return new WaitForSeconds (UnityEngine.Random.Range(0.2f, 0.35f));
			GameObject user_is_typing = Instantiate (user_is_typing_prefab);
			user_is_typing.transform.SetParent (chat_transform, false);
			user_is_typing.GetComponent<BantsMessageView>().SetMessage (current_page.name+" is typing...", "");

			float type_time = ((float)message.message.Length * .05f);
			if(type_time>2.1f){type_time=2.1f;}
			yield return new WaitForSeconds (type_time);
			Destroy (user_is_typing);
			QF_GlobalSound.Play (SoundLibrary.ReceiveMessage);
			GameObject new_message_gameobject = Instantiate (received_message_prefab);
			new_message_gameobject.GetComponent<BantsMessageView>().SetMessage (message.message, DateTime.Now.ToString());
			new_message_gameobject.transform.SetParent (chat_transform, false);
		}


		//If there are user responses for this message
		if(current_page.messages[current_message].responses.Count>0){
			for(int i=0;i<current_page.messages[current_message].responses.Count;i++)
			{
				GameObject new_response_gameobject = Instantiate (response_prefab) as GameObject;
				new_response_gameobject.GetComponent<BantsResponseButton>().SetupResponse (current_page.messages[current_message].responses[i].message, current_page.name, current_page.messages[current_message].responses[i].progress);
				new_response_gameobject.transform.SetParent (response_transform, false);
				response_buttons.Add (new_response_gameobject);
			}
		}
		else{ //if there are no responses
			current_message ++;
			EnterMessage ();
		}
	}

	IEnumerator WaitAndEnterChat (string name, int progress)
	{
		yield return new WaitForSeconds (UnityEngine.Random.Range(1.1f, 2.1f));
		EnterChat (name, progress);
	}

	public void ResponseClicked (string message, string name, int progress)
	{
		for(int i=0;i<response_buttons.Count;i++){Destroy(response_buttons[i]);}
		response_buttons.Clear ();

		GameObject new_header_gameobject = Instantiate (sent_message_header);
		new_header_gameobject.GetComponent<TextLink>().text.text = PlayerData.instance.username;
		new_header_gameobject.transform.SetParent (chat_transform, false);

		GameObject new_message_gameobject = Instantiate (sent_message_prefab);
		new_message_gameobject.GetComponent<BantsMessageView>().SetMessage (message, DateTime.Now.ToString());
		new_message_gameobject.transform.SetParent (chat_transform, false);

		StartCoroutine (WaitAndEnterChat (name, progress));
	}
*/

	//To support multiple channels, here we store the connection between the channel id, and the ui content view in the scene that will display those messages.
	public List<ChannelTransformConnection> channel_transform_connections = new List<ChannelTransformConnection>();

	public void Start ()
	{
		StartCoroutine (TestThread ());
	}

	string[] senders = {"John", "Paul", "Mary"};

	public IEnumerator TestThread ()
	{
		while(true)
		{
			yield return new WaitForSeconds (UnityEngine.Random.Range (1f,3f));
			ReceiveMessage (senders[UnityEngine.Random.Range(0,3)], UnityEngine.Random.Range(1,100).ToString (), DateTime.Now.ToString());
		}
	}



	public InputField input_text_field;

	public int old_object_limit = 100;

	private NetworkClient _network;

	public Dropdown channel_dropdown;


	private List<GameObject> old_objects = new List<GameObject>(); //Store our created gameobjects, so we can delete old ones if we have too many.
	private string last_received_message_sender = "";

	public void Initialize (NetworkClient network_client)
	{
		_network = network_client;

		//Register for Messages
		_network.RegisterHandler(ChatServerMessageTypes.ChannelMessage, OnChannelMessage);
	}


	private void OnChannelMessage(NetworkMessage netMsg)
	{
		var chat_message = netMsg.ReadMessage<ChatMessage>();

		ReceiveMessage (chat_message.SenderUserId, chat_message.Message, chat_message.Timestamp.ToString ());
	}

	public void ChannelDropdown(int index)
	{
		if ("Create Channel..." == channel_dropdown.options[index].text){
			_network.Send(ChatServerMessageTypes.CreateChannel, new CreateChannelMessage()
				{
					
				});
		}
		else{	 //Selected existing channel:
			for(int i=0;i<channel_transform_connections.Count;i++){
				if (channel_transform_connections[i].ChannelId == channel_dropdown.options[index].text){
					channel_transform_connections[i].ChatContentTransform.gameObject.SetActive (true);
				}
				else{
					channel_transform_connections[i].ChatContentTransform.gameObject.SetActive (false);
				}
			}
		}
	}


	//User clicked Send message button.
	public void SendMessageButtonClicked ()
	{
		if (input_text_field.text != "")
		{

		}
	}

	//User received a chat message.
	public void ReceiveMessage (string sender, string message, string timestamp)
	{
		if(sender != last_received_message_sender){
			GameObject new_header_gameobject = Instantiate (received_message_header) as GameObject;
			new_header_gameobject.GetComponent<TextLink>().text.text = sender;
			new_header_gameobject.transform.SetParent (chat_transform, false);
			last_received_message_sender = sender;
			AddToObjectList (new_header_gameobject);
		}

		//QF_GlobalSound.Play (SoundLibrary.ReceiveMessage);
		GameObject new_message_gameobject = Instantiate (received_message_prefab);
		new_message_gameobject.GetComponent<ChatMessageView>().SetMessage (message, timestamp);
		new_message_gameobject.transform.SetParent (chat_transform, false);
		AddToObjectList (new_message_gameobject);
	}

	public void AddToObjectList (GameObject old_object)
	{
		old_objects.Add (old_object);

		if(old_objects.Count > old_object_limit){ //If over chat object limit, destroy oldest one.
			Destroy (old_objects[0]);
			old_objects.RemoveAt (0);
		}
	}

}
