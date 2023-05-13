using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void backToMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
}
