using System.Collections;
using UnityEngine;
using LootLocker.Requests;

public class ScoreSubmitter : MonoBehaviour
{
    string leaderboardKey = "leaderboardKey";

    public IEnumerator SubmitScoreRoutine(int highScore)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        string playerName = PlayerPrefs.GetString("PlayerName");
        LootLockerSDKManager.SubmitScore(playerID, highScore, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                LootLockerSDKManager.SetPlayerName(playerName, (response) => 
                {
                    if (response.success)
                    {
                        Debug.Log("Se ha cambiado el nombre a " + playerName);
                    }
                });
                Debug.Log("Uploaded score");
                done = true;
            }
            else
            {
                Debug.Log("Failed");
                done = true;
            }
        });

        yield return new WaitWhile(() => !done);
    }
}
