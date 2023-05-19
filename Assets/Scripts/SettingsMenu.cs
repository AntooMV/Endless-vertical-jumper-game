using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] Slider volumeSlider;
    
    
    void Start()
    {
        if(!PlayerPrefs.HasKey("PlayerName")) PlayerPrefs.SetString("PlayerName", "Guest");
        if(!PlayerPrefs.HasKey("GlobalVolume")) PlayerPrefs.SetFloat("GlobalVolume", 1f);
        Load();
    }

    void Load()
    {
        usernameField.text = PlayerPrefs.GetString("PlayerName");
        volumeSlider.value = PlayerPrefs.GetFloat("GlobalVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetString("PlayerName", usernameField.text);
        PlayerPrefs.SetFloat("GlobalVolume", volumeSlider.value);
    }

    public void Click() {FindObjectOfType<AudioManager>().Play("Click");}

}
