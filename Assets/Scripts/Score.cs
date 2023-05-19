using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public Transform player;
    public int score;
    private double pos, timedScore = 0f;
    [SerializeField] TMP_Text scoreText;

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            pos = player.position.y > pos ? player.position.y : pos;
            timedScore += .0167f;
            score = (int)(timedScore + pos);
            scoreText.text = score.ToString("0");        
        }
    }
}
