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

    private void Awake()
    {
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

    public void LoadData(GameData data)
    {
        SetlevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        experienceNumber = levelSystem.GetExperience();
        expToNextLevelNumber = levelSystem.GetExpToNextLevel();
        SetTextBar(experienceNumber, expToNextLevelNumber);
    }

    public void SaveData(GameData data)
    {

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

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        if (this == null) return;
        // Experience Changed, update text and bar size
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());
        experienceNumber = levelSystem.GetExperience();
        expToNextLevelNumber = levelSystem.GetExpToNextLevel();
        SetTextBar(experienceNumber, expToNextLevelNumber);
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        if (this == null) return;
        // Level changed, update text
        SetlevelNumber(levelSystem.GetLevelNumber());
    }
}