using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] sounds;
    [Range(0f, 1f)]
    public float globalVolume = .5f;


    void Start()
    {
        Play("BGM");
    }

    void Update()
    {
        globalVolume = PlayerPrefs.GetFloat("GlobalVolume", .5f);
        instance.GetComponent<AudioSource>().volume = globalVolume;
    }

    void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Play();
    }
}
