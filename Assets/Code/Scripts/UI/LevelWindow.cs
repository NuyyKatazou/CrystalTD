using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour, IDataPersistence
{
    [Header("References")]
    [SerializeField] private TMPro.TMP_Text barText;
    [SerializeField] private TMPro.TMP_Text levelText;
    [SerializeField] private Image experienceBarImage;

    public LevelSystem levelSystem;
    private int experienceNumber;
    private int expToNextLevelNumber;

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        // Set the LevelSystem object
        this.levelSystem = levelSystem;

        // Update the Starting values
        SetlevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        experienceNumber = levelSystem.GetExperience();
        expToNextLevelNumber = levelSystem.GetExpToNextLevel();
        SetTextBar(experienceNumber, expToNextLevelNumber);

        // Subscribe to the changed events
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        // Experience Changed, update text and bar size
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        experienceNumber = levelSystem.GetExperience();
        expToNextLevelNumber = levelSystem.GetExpToNextLevel();
        SetTextBar(experienceNumber, expToNextLevelNumber);
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        // Level changed, update text
        SetlevelNumber(levelSystem.GetLevelNumber());
    }

    public void LoadData(GameData data)
    {
        levelSystem.level = data.level;
        levelSystem.experience = data.experience;
        levelSystem.experienceToNextLevel = data.experienceToNextLevel;
        SetlevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        experienceNumber = levelSystem.GetExperience();
        expToNextLevelNumber = levelSystem.GetExpToNextLevel();
        SetTextBar(experienceNumber, expToNextLevelNumber);
    }

    public void SaveData(GameData data)
    {
        data.level = levelSystem.level;
        data.experience = levelSystem.experience;
        data.experienceToNextLevel = levelSystem.experienceToNextLevel;
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetTextBar(int experienceNumber, int expToNextLevelNumber)
    {
        barText.text = experienceNumber + " / " + expToNextLevelNumber;
    }

    private void SetlevelNumber(int levelNumber)
    {
        levelText.text = levelNumber.ToString();
    }
}
