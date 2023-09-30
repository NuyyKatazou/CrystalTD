using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour, IDataPersistence
{
    public static LevelSystem mainLevelSystem { get; private set; }

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private static readonly int[] experiencePerLevel = new[] { 0, 50, 100, 150, 200, 250, 500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500, 2750, 3000, 3250, 3500, 3750, 4000, 4250, 4500, 4750, 5000, 5500, 6000, 6500, 7000, 7500, 8000, 8500, 9000, 9500, 10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000, 21000, 22000, 23000, 24000, 25000, 27500, 30000, 32500, 35000, 37500, 40000, 42500, 45000, 47500, 50000, 55000, 60000, 65000, 70000, 75000, 80000, 85000, 90000, 95000, 100000, 110000, 120000, 130000, 140000, 150000, 160000, 170000, 180000, 190000, 200000, 250000, 300000, 350000, 400000, 450000, 500000, 550000, 600000, 650000, 700000, 750000, 1000000, 1250000, 1500000, 1750000, 2000000, 2500000, 5000000, 25000000, 999999999 };

    private int level;
    private int experience;

    private void Awake()
    {
        if (mainLevelSystem != null)
        {
            Debug.Log("Found more than one LevelSystem in the scene. Destroying the newest one.");
            Destroy(this);
            return;
        }
        mainLevelSystem = this;
    }

    public void LoadData(GameData data)
    {
        this.level = data.level;
        this.experience = data.experience;
    }

    public void SaveData(GameData data)
    {
        data.level = this.level;
        data.experience = this.experience;
    }

    public void AddExperience(int amount)
    {
        if (!IsMaxLevel())
        {
            experience += amount;
            while (!IsMaxLevel() && experience >= GetExpToNextLevel(level))
            {
                // Enough experience to level up
                experience -= GetExpToNextLevel(level);
                level++;
                if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
            }
            if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetExpToNextLevel()
    {
        return GetExpToNextLevel(level);
    }

    public int GetExpToNextLevel(int level)
    {
        if (level < experiencePerLevel.Length)
        {
            return experiencePerLevel[level];
        }
        else
        {
            // Level Invalid
            Debug.LogError("Level invalid: " + level);
            return 999999;
        }
    }

    public float GetExperienceNormalized()
    {
        if (IsMaxLevel())
        {
            return 1f;
        }
        else
        {
            return (float)experience / GetExpToNextLevel(level);
        }
    }

    public bool IsMaxLevel()
    {
        return IsMaxLevel(level);
    }

    public bool IsMaxLevel(int level)
    {
        return level == experiencePerLevel.Length - 1;
    }
}
