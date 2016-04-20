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

	public Transform chat_transform;
	public GameObject received_message_header;
	public GameObject received_message_prefab;
	public GameObject sent_message_header;
	public GameObject sent_message_prefab;

	public InputField chat_diplay_name_text;

	private List<GameObject> response_buttons = new List<GameObject>();
	private List<GameObject> contact_buttons = new List<GameObject>();


	//To support multiple channels, here we store the connection between the channel id, and the ui content view in the scene that will display those messages.
	public List<ChannelTransformConnection> channel_transform_connections = new List<ChannelTransformConnection>();


	public InputField input_text_field;

	public int old_object_limit = 100;

	public string PlayerUsername = "Newbie";

	public Dropdown channel_dropdown;

	public Transform chat_window_transform;

	public GameObject chat_content_prefab;

	public Button send_button;

	private string PlayFabId;

	private NetworkClient _network;



	private string current_channel_id;

	private List<GameObject> old_objects = new List<GameObject>(); //Store our created gameobjects, so we can delete old ones if we have too many.
	private string last_received_message_sender = "";

	public void Initialize (NetworkClient network_client, string playFabId)
	{
		_network = network_client;
		PlayFabId = playFabId;
		//Register for Messages
		_network.RegisterHandler(ChatServerMessageTypes.ChannelMessage, OnChannelMessage);
		_network.RegisterHandler(ChatServerMessageTypes.JoinChannelResponse, OnJoinChannelResponse);
		_network.RegisterHandler(ChatServerMessageTypes.CreateChannelResponse, OnCreateChannelResponse);

		Debug.Log ("send create channel");
		_network.Send(ChatServerMessageTypes.CreateChannel, new CreateChannelMessage()
			{
				ChannelId = "General",
				MemberId = PlayFabId,
				MemberName = PlayerUsername,
				IsInviteOnly = false
			});

		chat_diplay_name_text.text = PlayerUsername;
	}

	public void OnPlayerChangeUserName ()
	{
		PlayerUsername = chat_diplay_name_text.text;
	}

	private void OnCreateChannelResponse(NetworkMessage netMsg)
	{
		Debug.Log ("OnCreateChannelResponse");

		var response_message = netMsg.ReadMessage<CreateChannelResponseMessage>();

		if(response_message.Created)
		{
			GameObject new_object = Instantiate (chat_content_prefab) as GameObject;
			Transform new_transform = new_object.transform;
			new_transform.SetParent (chat_window_transform, false);

			channel_transform_connections.Add (new ChannelTransformConnection() {
				ChannelId = response_message.ChannelId,
				ChatContentTransform = new_transform
			});

			channel_dropdown.AddOptions( new List<string>() {response_message.ChannelId});
			current_channel_id = response_message.ChannelId;
			channel_dropdown.value = channel_dropdown.options.Count-1; //select the new room

			send_button.interactable = true;
			input_text_field.interactable = true;

		}
	}

	private void OnJoinChannelResponse(NetworkMessage netMsg)
	{
		Debug.Log ("OnJoinChannelResponse");

		var response_message = netMsg.ReadMessage<JoinChannelResponseMessage>();

		if(response_message.Joined)
		{
			GameObject new_object = Instantiate (chat_content_prefab) as GameObject;
			Transform new_transform = new_object.transform;
			new_transform.SetParent (chat_window_transform, false);

			channel_transform_connections.Add (new ChannelTransformConnection() {
				ChannelId = response_message.ChannelId,
				ChatContentTransform = new_transform
			});

			channel_dropdown.AddOptions( new List<string>() {response_message.ChannelId});
			current_channel_id = response_message.ChannelId;
			channel_dropdown.value = channel_dropdown.options.Count-1; //select the new room

			send_button.interactable = true;
			input_text_field.interactable = true;
		}
	}

	private void OnChannelMessage(NetworkMessage netMsg)
	{
		var chat_message = netMsg.ReadMessage<ChatMessage>();

		ReceiveMessage (chat_message.SenderUserName, chat_message.Message, chat_message.Timestamp.ToString ());
	}

	public void ChannelDropdown(int index)
	{
		Debug.Log ("ChannelDropdown "+index + " "+channel_dropdown.options[index].text);
		if ("Create Channel..." == channel_dropdown.options[index].text){
			Debug.Log ("Create Channel");
			_network.Send(ChatServerMessageTypes.CreateChannel, new CreateChannelMessage()
				{
					MemberId = PlayFabId,
					MemberName = PlayerUsername,
					IsInviteOnly = true
				});
		}
		else{	 //Selected existing channel:
			Debug.Log ("existing Channel");
			for(int i=0;i<channel_transform_connections.Count;i++){
				if (channel_transform_connections[i].ChannelId == channel_dropdown.options[index].text){
					Debug.Log ("found channel");
					channel_transform_connections[i].ChatContentTransform.gameObject.SetActive (true);
					chat_transform = channel_transform_connections[i].ChatContentTransform;
					chat_window_transform.gameObject.GetComponent<ScrollRect>().content = (RectTransform)chat_transform;
				}
				else{ //otherwise deactivate:
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
			
			_network.Send(ChatServerMessageTypes.ChannelMessage, new ChatMessage()
				{
					ChannelId = current_channel_id,
					SenderUserId = PlayFabId,
					SenderUserName = PlayerUsername,
					Message = input_text_field.text,
					Timestamp = DateTime.Now
				});

			GameObject new_header_gameobject = Instantiate (sent_message_header);
			new_header_gameobject.GetComponent<TextLink>().text.text = PlayerUsername;
			new_header_gameobject.transform.SetParent (chat_transform, false);

			GameObject new_message_gameobject = Instantiate (sent_message_prefab);
			new_message_gameobject.GetComponent<ChatMessageView>().SetMessage (input_text_field.text, DateTime.Now.ToString());
			new_message_gameobject.transform.SetParent (chat_transform, false);

			input_text_field.text = "";
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
