using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float maxHeight, minHeight, desiredHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform background;
    [SerializeField] GameManager gameManager;
    public bool cameraFollows;

    void Start()
    {
        
    }
    void Update()
    {
        keepOnStage();
        checkGameOver();   
    }

    void keepOnStage() 
    {        
        maxHeight = background.position.y + 37;
        minHeight = background.position.y - 37;
        desiredHeight = desiredHeight <= player.position.y + 15 ? player.position.y + 15 : desiredHeight;

        if (desiredHeight < minHeight)
        {
            desiredHeight = minHeight;
        }
        if (desiredHeight > maxHeight)
        {
            desiredHeight = maxHeight;
        }
        transform.position = new Vector3(0, desiredHeight, -2);
    }

    void checkGameOver()
    {
        if (player.position.y < transform.position.y - 55)
        {
            gameManager.GameOver();
            FindObjectOfType<AudioManager>().Play("Death");
        }
    }
}
