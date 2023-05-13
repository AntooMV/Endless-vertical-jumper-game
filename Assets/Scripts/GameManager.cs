using UnityEngine;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
using System.Collections;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    [SerializeField] Score score;
    [SerializeField] ScoreSubmitter scoreSubmitter;

    public string playerName;
    public int highScore;

    void Start()
    {
        playerName = PlayerPrefs.GetString("playerName", "Guest");
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        StartCoroutine(LoginRoutine());
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

    public void GameOver()
    {
        if (!gameEnded)
        {
            if (score.score > highScore) 
            {
                highScore = score.score;
                PlayerPrefs.SetInt("Highscore", score.score);
                StartCoroutine(scoreSubmitter.SubmitScoreRoutine(highScore));
            }
            gameEnded = true;
            Debug.Log(playerName + " / Score: " + score.score.ToString() + ", Highscore: " + highScore.ToString());
            Restart();
        }
    }
    
    void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    void ClearScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }
}
