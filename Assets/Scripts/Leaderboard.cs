using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    string leaderboardKey = "leaderboardKey";
    public TextMeshProUGUI displayedRanks, displayedIds, displayedNames, displayedScores;

    void Start()
    {
        StartCoroutine(FetchTopHighscoresRoutine());
    }

    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 100, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerRanks = "";
                string tempPlayerIds = "";
                string tempPlayerNames = "";
                string tempPlayerScores = "";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerIds += members[i].member_id + "\n";
                    tempPlayerNames += members[i].player.name != "" ? members[i].player.name : "Guest";
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                for (int i = 1 ; i < 101 ; i++) tempPlayerRanks += i.ToString() + "\n";

                tempPlayerIds += string.Concat(Enumerable.Repeat("--------\n", 100 - members.Length));
                tempPlayerNames += string.Concat(Enumerable.Repeat("--------\n", 100 - members.Length));
                tempPlayerScores += string.Concat(Enumerable.Repeat("--------\n", 100 - members.Length));

                displayedRanks.text = tempPlayerRanks;
                displayedIds.text = tempPlayerIds;
                displayedNames.text = tempPlayerNames;
                displayedScores.text = tempPlayerScores;
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        
        yield return new WaitWhile(() => !done);
    }
}
