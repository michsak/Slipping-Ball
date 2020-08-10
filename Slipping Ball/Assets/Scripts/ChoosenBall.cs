using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenBall : MonoBehaviour
{
    int materialNumber = 0;
    int totalMoney;
    int lastLevel = 1;
    string boughtBalls;
    PlayerMovement playerMovement;
    BuyItemsInShop buyItemsInShop;
    [SerializeField] List<int> ownedBalls = new List<int> { 0 };

    private void Start()
    {
        totalMoney = PlayerPrefsController.GetTotalMoney();

        if (FindObjectsOfType<ChoosenBall>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Update()
    {
        if (FindObjectOfType<BuyItemsInShop>())
        {
            buyItemsInShop = FindObjectOfType<BuyItemsInShop>();
            materialNumber = buyItemsInShop.GetBallNumber();
        }

        if (FindObjectOfType<PlayerMovement>())
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            playerMovement.SetMaterialNumber(materialNumber);
        }
    }

    public void AppendOnOwnedBalls(int BallNb)
    {
        ownedBalls.Add(BallNb);
    }

    public List<int> GetOwnedBalls()
    {
        return ownedBalls;
    }

    public void SetTotalMoney(int money)
    {
        totalMoney = money;
        PlayerPrefsController.SetTotalMoney(totalMoney);
    }

    public void AddToTotalMoney(int howMuch)
    {
        totalMoney += howMuch;
        PlayerPrefsController.SetTotalMoney(totalMoney);
    }

    public int GetTotalMoney()
    {
        return totalMoney;
    }
}
