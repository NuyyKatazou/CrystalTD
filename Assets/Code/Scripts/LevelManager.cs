using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, IDataPersistence
{
    public static LevelManager main { get; private set; }

    [Header("References")]
    public DefeatMenu defeatMenu;
    public ShopMenu shopMenu;

    public Transform startPoint;
    public Transform[] path;

    public PlayerHealth playerHealth = new PlayerHealth(100, 100);

    public int currency;
    public int baseCurrency;
    public bool gameLose = false;
    public bool gameWin = false;
    public bool tutorialEnd = false;

    public void LoadData(GameData data)
    {
        baseCurrency = data.baseCurrency;
        tutorialEnd = data.tutorialEnd;
    }

    public void SaveData(GameData data)
    {
        data.baseCurrency = baseCurrency;
        data.tutorialEnd = tutorialEnd;
    }

    private void Awake()
    {
        if (main != null)
        {
            Destroy(this);
            return;
        }

        main = this;
    }

    private void Start()
    {
        if (baseCurrency == 0)
        {
            baseCurrency = 100;
        }
        currency = baseCurrency;
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
