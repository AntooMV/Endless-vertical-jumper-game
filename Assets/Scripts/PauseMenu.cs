using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    public static bool isPaused = false;

    void Start()
    {
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void PauseGame() 
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame() 
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void BackToMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void Click() {FindObjectOfType<AudioManager>().Play("Click");}
}
