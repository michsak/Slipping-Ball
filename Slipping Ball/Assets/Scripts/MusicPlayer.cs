using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
            {
            DontDestroyOnLoad(this);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
