using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    public int level;
    public int experience;
    public int experienceToNextLevel;

    public LevelSystem()
    {
        level = 1;
        experience = 0;
        experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            // Enough experience to level up
            level++;
            experience -= experienceToNextLevel;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
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
        return experienceToNextLevel;
    }

    public float GetExperienceNormalized()
    {
        return (float)experience / (float)experienceToNextLevel;
    }
}
