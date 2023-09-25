using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main { get; private set; }

    [Header("References")]
    public DefeatMenu defeatMenu;
    public ShopMenu shopMenu;

    public Transform startPoint;
    public Transform[] path;

    public PlayerHealth playerHealth = new PlayerHealth(100, 100);

    public int currency;
    public bool gameLose = false;
    public bool gameWin = false;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
        gameLose = false;
        gameWin = false;
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            defeatMenu.OpenDefeatCanvas();
            shopMenu.CloseShopCanvas();
            MenuUIHandler.mouse_over = true;
            gameLose = true;
        }
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }
}
