using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    const string SETTINGS_KEY = "Settings";
    const string SHOP_KEY = "Shop";
    const string LEVELS_KEY = "Levels";
    const string LEVEL_1 = "Level 1";
    const string LEVEL_2 = "Level 2";
    const string LEVEL_3 = "Level 3";
    const string LEVEL_4 = "Level 4";
    int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
        PauseButton pauseButton = FindObjectOfType<PauseButton>();
        DisplayStarsNumber displayStarsNumber = FindObjectOfType<DisplayStarsNumber>();
        if (pauseButton)
        {
            pauseButton.ContinueGame();
        }
        if (displayStarsNumber)
        {
            displayStarsNumber.EndOfLevel();
        }
        if (currentScene == 4)
        {
            SceneManager.LoadScene(0);  //if end of game load start menu, may bo to updated
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(SETTINGS_KEY);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        if (FindObjectOfType<DisplayLevel>())
        {
            FindObjectOfType<DisplayLevel>().SetCurrentLevel(1); //while lading main menu Set Current Level to 1
            Destroy(GameObject.Find("Level"));
        }
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(SHOP_KEY);
    }

    public void LoadAvailableLevels()
    {
        SceneManager.LoadScene(LEVELS_KEY);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(LEVEL_1);
    }

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene(LEVEL_2);
    }

    public void LoadThirdLevel()
    {
        SceneManager.LoadScene(LEVEL_3);
    }

    public void LoadFourthLevel()
    {
        SceneManager.LoadScene(LEVEL_4);
    }

    public int GetCurrentLevel()
    {
        return currentScene;
    }
}
