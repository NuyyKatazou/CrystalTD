using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour, IDataPersistence
{
    [Header("References")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private TMPro.TMP_Text versionText;
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private Button playButton;
    [SerializeField] private Button achievementButton;

    private LevelWindow levelSystem;

    public PlayMenu playMenu;
    public OptionsMenu optionsMenu;

    private string version;

    public bool tutorialEnd = false;

    public void LoadData(GameData data)
    {
        tutorialEnd = data.tutorialEnd;
    }

    public void SaveData(GameData data)
    {
        data.tutorialEnd = tutorialEnd;
    }

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();

        levelWindow.SetLevelSystem(levelSystem);
    }

    private void Start()
    {
        versionText.text = Application.version;

        if (!DataPersistenceManager.instance.HasGameData())
        {
            achievementButton.interactable = false;
        }
    }

    public void PlayButton()
    {
        if (tutorialEnd == false)
        {
            DisableMenuButtons();
            // Load the Tutorial scene - wich will turn save the game because of
            // OnSceneLoaded() in the DataPersistenceManager
            ChangeScene("TutorialLevel");
        }
        if (tutorialEnd == true)
        {
            playMenu.OpenPlayCanvas();
            CloseMenuCanvas();
        }
    }

    public void OptionsButton()
    {
        optionsMenu.OpenOptionsCanvas();
    }

    public void WikiButton()
    {

    }

    public void AchievementButton()
    {

    }

    public void VersionButton()
    {

    }

    public void CreditsButton()
    {

    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenMenuCanvas()
    {
        menuPanel.SetActive(true);
    }

    public void CloseMenuCanvas()
    {
        menuPanel.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        playButton.interactable = false;
    }
}
