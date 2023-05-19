using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Game");
    }

    public void Click() {FindObjectOfType<AudioManager>().Play("Click");}

    public void QuitGame()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
