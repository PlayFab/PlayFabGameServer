using PlayFab;
using UnityEngine;

public class PlayFabErrorHandler
{
    public static void HandlePlayFabError(PlayFabError error)
    {
        Debug.Log(error.ErrorMessage);
        if (error.ErrorDetails == null)
        {
            return;
        }

        foreach (var kvp in error.ErrorDetails)
        {
            foreach (var s in kvp.Value)
            {
                Debug.Log(s);
            }
        }
    }
}
