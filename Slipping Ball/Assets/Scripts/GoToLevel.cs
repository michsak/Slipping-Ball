using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToLevel : MonoBehaviour
{
    [SerializeField] int lastLevel;
    [SerializeField] GameObject[] levelsButtons;
    [SerializeField] GameObject[] levelsLockers;

    private void Start()
    {
        lastLevel = PlayerPrefsController.GetAvailableLevels();

        for (int i = 0; i < lastLevel; i++)
        {
            levelsButtons[i].GetComponent<Button>().enabled = true;
            levelsLockers[i].SetActive(false);
        }

        for (int j = lastLevel; j < levelsButtons.Length; j++)
        {
            levelsLockers[j].SetActive(true);
            levelsButtons[j].GetComponent<Button>().enabled = false;
        }
    }
}
