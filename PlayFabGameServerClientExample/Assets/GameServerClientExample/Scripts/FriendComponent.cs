using UnityEngine;
using System.Collections;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class FriendComponent : MonoBehaviour {

    public void AddButtonClicked(Button sender)
    {
        var playerIdText = sender.GetComponentInChildren<Text>();
        if (playerIdText == null) return;
        if (playerIdText.text == "Add Friend")
        {
            var request = new AddFriendRequest() { FriendPlayFabId = sender.name };
            Debug.Log(sender.name);
            PlayFabClientAPI.AddFriend(request, result =>
            {
                if (result.Created)
                {
                    sender.GetComponentInChildren<Text>().text = "Gift";
                }
            }, error =>
            {
                if (error.Error == PlayFabErrorCode.UsersAlreadyFriends)
                {
                    sender.GetComponentInChildren<Text>().text = "Gift";
                }
            });
        }
        else if (playerIdText.text == "Gift")
        {
            PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest() { FunctionName = "grantItemToPlayer", FunctionParameter = new {benefiter = sender.name}, GeneratePlayStreamEvent = false}, urlResult =>
            {
                Debug.Log("success cloud scipt!");
            }, error =>
            {
                Debug.Log(error.ErrorMessage);
            });
        }
    }
}
