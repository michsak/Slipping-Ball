using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider vibrationsSlider;
    float defaultVolume = 0.5f;
    int defultVibrations = 1;


    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        vibrationsSlider.value = PlayerPrefsController.GetVibrations();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void Save()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetVibrations(Mathf.RoundToInt(vibrationsSlider.value));
        if (PlayerPrefsController.GetVibrations() == 1)
        {
            Vibration.Vibrate(100);
        }
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void Defaults()
    {
        volumeSlider.value = defaultVolume;
        vibrationsSlider.value = defultVibrations;
        if (PlayerPrefsController.GetVibrations() == 1)
        {
            Vibration.Vibrate(100);
        }
    }

    public float GetPlayerVolumeSettings()
    {
        return volumeSlider.value;
    }
}
