using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string MASTER_VIBRATIONS_KEY = "vibrations";
    const string LEVEL_KEY = "level";
    const string MONEY_KEY = "money";
    const int defaultMoneyValue = 5;
    const int defaultLevel = 1;

    public static void SetMasterVolume(float volume)
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    }

    public static void SetVibrations(int vib)
    {
        PlayerPrefs.SetInt( MASTER_VIBRATIONS_KEY, vib);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static int GetVibrations()
    {
        return PlayerPrefs.GetInt(MASTER_VIBRATIONS_KEY);
    }

    public static void SetAvailableLevels(int lvl)
    {
        PlayerPrefs.SetInt(LEVEL_KEY, lvl);
    }

    public static int GetAvailableLevels()
    {
        return PlayerPrefs.GetInt(LEVEL_KEY, defaultLevel);
    }

    public static void SetTotalMoney(int money)
    {
        PlayerPrefs.SetInt(MONEY_KEY, money);
    }

    public static int GetTotalMoney()
    {
        return PlayerPrefs.GetInt(MONEY_KEY, defaultMoneyValue);
    }
}
