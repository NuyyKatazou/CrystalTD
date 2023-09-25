using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    public int currentHealth = 100;
    public int currentMaxHealth = 100;

    public int Health
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return currentMaxHealth;
        }
        set
        {
            currentMaxHealth = value;
        }
    }
    public PlayerHealth(int health, int maxHealth)
    {
        currentHealth = health;
        currentMaxHealth = maxHealth;
    }

    public void DmgPlayer(int dmgAmount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmgAmount;
        }
        Debug.Log("Player Take Damage. Player now have " + LevelManager.main.playerHealth.Health + " Hp.");
    }

    public void HealPlayer(int healAmount)
    {
        if (currentHealth < currentMaxHealth)
        {
            currentHealth += healAmount;
        }
        if (currentHealth > currentMaxHealth)
        {
            currentHealth = currentMaxHealth;
        }
        Debug.Log("Player Has Been Healed. Player now have " + LevelManager.main.playerHealth.Health + " Hp.");
    }
}
