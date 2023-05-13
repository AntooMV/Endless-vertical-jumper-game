using System.Collections;
using LootLocker.Requests;
using UnityEngine;

public class LeaderboardMenu : MonoBehaviour
{
    [SerializeField] Leaderboard leaderboard;

    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }
    
    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Not logged in");
                done = true;
            }
        });
        yield return new WaitWhile(() => !done);
    }
}
