using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStarsNumber : MonoBehaviour
{
    ChoosenBall choosenBall;
    [SerializeField] Text StarsText;
    int currentStarsNumber = 0;     //is set from ChoosenBall
    int totalStarsNumber = 20;      //player prefs

    void Start()
    {
        if (FindObjectsOfType<DisplayStarsNumber>().Length > 1)
        {
            Destroy(gameObject);
        }
        else { DontDestroyOnLoad(gameObject); }

        if (FindObjectOfType<ChoosenBall>())
        {
            choosenBall = FindObjectOfType<ChoosenBall>();
            totalStarsNumber = choosenBall.GetTotalMoney();
        }
        DisplayCurrentStarsNumber();
    }

    public void Update()
    {
        DisplayCurrentStarsNumber();
    }

    private void DisplayCurrentStarsNumber()
    {
        StarsText.text = (totalStarsNumber + currentStarsNumber).ToString();
    }

    public void AddStars(int number)
    {
        currentStarsNumber += number;
        choosenBall.AddToTotalMoney(number);
        DisplayCurrentStarsNumber();
    }

    public void ResetTheStars() //if current star's after evert loosing = 0
    {
        currentStarsNumber = 0;
        DisplayCurrentStarsNumber();
    }

    public void EndOfLevel()        //here choosenBall.AddTotalMoney(number) when want to add to total every single move
    {
        totalStarsNumber = totalStarsNumber + currentStarsNumber;
        currentStarsNumber = 0;
    }

    public int GetTotalStarsNumber()
    {
        return totalStarsNumber;
    }
}
