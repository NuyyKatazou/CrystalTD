using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    public int experience;

    public int baseCurrency;

    public bool tutorialEnd;

    // The values defined in this constructor will be the default values
    // The game starts with when there's no data to load
    public GameData()
    {
        this.level = 1;
        this.experience = 0;

        this.baseCurrency = 100;

        this.tutorialEnd = false;
    }
}
