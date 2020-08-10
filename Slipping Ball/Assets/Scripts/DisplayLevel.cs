using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : MonoBehaviour
{
    [SerializeField] Text levelText;
    int currentLevel = 1;

    void Start()
    {
        if (FindObjectOfType<LevelLoader>())
        {
            currentLevel = FindObjectOfType<LevelLoader>().GetCurrentLevel();
        }
        DisplayCurrentLevel();
    }

    private void DisplayCurrentLevel()
    {
        levelText.text = "Level " + currentLevel.ToString();
    }

    public void SetCurrentLevel(int param)
    {
        currentLevel = param;
        DisplayCurrentLevel();
    }

    public void AddLevel()
    {
        currentLevel += 1;
        DisplayCurrentLevel();
        if (currentLevel > PlayerPrefsController.GetAvailableLevels())
        {
            PlayerPrefsController.SetAvailableLevels(currentLevel);
        }
    }
}
