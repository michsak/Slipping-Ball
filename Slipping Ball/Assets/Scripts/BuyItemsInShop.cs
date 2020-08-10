using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemsInShop : MonoBehaviour
{
    int ballNumber = 0;
    int totalCoinsNumber;
    LevelLoader levelLoader;
    ChoosenBall choosenBall;
    [SerializeField] Text coinsText;
    [SerializeField] GameObject[] ballsLockers;
    [SerializeField] GameObject[] ballButtons;
    [SerializeField] GameObject[] ballPrices;
    [SerializeField] GameObject[] showPrice;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        choosenBall = FindObjectOfType<ChoosenBall>();
        totalCoinsNumber = PlayerPrefsController.GetTotalMoney();
        coinsText.text = totalCoinsNumber.ToString();
        IsOnList();
    }

    private void Update()
    {
        BuyBalls();
    }

    private void IsOnList()
    {
        for (int i = 0; i <= choosenBall.GetOwnedBalls().Count; i++)
        {
            if (IsAlreadyBought(i+1) == true)
            {
                showPrice[i].SetActive(false);
                ballsLockers[i].SetActive(false);
            }
        }
    }

    public void ChooseBasicBall()
    {
        ballNumber = 0;
        #if !UNITY_ANDROID && UNITY_EDITOR
            BoughtBalls.saveFile(ballNumber);
        #endif
        levelLoader.LoadMainMenu();
    }

    private bool IsAlreadyBought(int ballNumber)
    {
    #if UNITY_ANDROID && !UNITY_EDITOR
        if (BoughtBalls.loadFile().Contains(ballNumber.ToString()))
            {
                return true;
            }
        else { return false; }

    #else
        if (choosenBall.GetOwnedBalls().Contains(ballNumber))
        {
            return true;
        }
        else { return false; }
    #endif
    }

    public void ChooseBloodyBall()
    {
        int bloodyBallInLabelNb = 0;
        ballNumber = 1;
        if (IsAlreadyBought(ballNumber) == false)
        {
            totalCoinsNumber = totalCoinsNumber - int.Parse(ballPrices[bloodyBallInLabelNb].GetComponent<Text>().text);
            choosenBall.AppendOnOwnedBalls(ballNumber);
            choosenBall.SetTotalMoney(totalCoinsNumber);
            #if UNITY_ANDROID && !UNITY_EDITOR
                BoughtBalls.saveFile(ballNumber);
            #endif

        }
        levelLoader.LoadMainMenu();
    }

    public void ChooseGlassyBall()
    {
        int glassyBallInLabelNb = 1;
        ballNumber = 2;
        if (IsAlreadyBought(ballNumber) == false)
        {
            totalCoinsNumber = totalCoinsNumber - int.Parse(ballPrices[glassyBallInLabelNb].GetComponent<Text>().text);
            choosenBall.AppendOnOwnedBalls(ballNumber);
            choosenBall.SetTotalMoney(totalCoinsNumber);
            #if UNITY_ANDROID && !UNITY_EDITOR
                BoughtBalls.saveFile(ballNumber);
            #endif
        }
        levelLoader.LoadMainMenu();
    }

    public void ChooseMeteorite()
    {
        int meteoriteLabelNb = 2;
        ballNumber = 3;
        if (IsAlreadyBought(ballNumber) == false)
        {
            totalCoinsNumber = totalCoinsNumber - int.Parse(ballPrices[meteoriteLabelNb].GetComponent<Text>().text);
            choosenBall.AppendOnOwnedBalls(ballNumber);
            choosenBall.SetTotalMoney(totalCoinsNumber);
            #if UNITY_ANDROID && !UNITY_EDITOR
                BoughtBalls.saveFile(ballNumber);
            #endif
        }
        levelLoader.LoadMainMenu();
    }

    public int GetBallNumber()
    {
        return ballNumber;
    }

    private void BuyBalls()
    {
        for (int i = 0; i < ballButtons.Length; i++)
        {
            if (int.Parse(ballPrices[i].GetComponent<Text>().text) <= totalCoinsNumber)
            {
                ballsLockers[i].GetComponent<Image>().enabled = false;
                ballButtons[i].GetComponent<Button>().enabled = true;
            }
            else if (IsAlreadyBought(i+1) == true)
            {
                ballButtons[i].GetComponent<Button>().enabled = true;
                ballsLockers[i].GetComponent<Image>().enabled = false;
                showPrice[i].SetActive(false);
            }
        }
    }
}
