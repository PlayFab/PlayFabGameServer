using PlayFab;
using UnityEngine;

public class PlayFabErrorHandler
{
    public static void HandlePlayFabError(PlayFabError error)
    {
        //TODO: Replace this entire Class with a command so that when playfab api errors happen they can be logged appropriately.
        //For now, these errors will only show up in the unity log.

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
