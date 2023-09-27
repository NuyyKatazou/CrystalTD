using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private TMPro.TMP_Text versionText;
    [SerializeField] private LevelWindow levelWindow;
    [SerializeField] private Button playButton;
    [SerializeField] private Button achievementButton;

    public static bool tutorialEnd = false;

    private LevelWindow levelSystem;
    public PlayMenu playMenu;
    private string version;

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
            // Create a new game - wich will initialize our game data
            DataPersistenceManager.instance.NewGame();
            // Load the Tutorial scene - wich will turn save the game because of
            // OnSceneUnloaded() in the DataPersistenceManager
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
        menuCanvas.SetActive(true);
    }

    public void CloseMenuCanvas()
    {
        menuCanvas.SetActive(false);
    }

    private void DisableMenuButtons()
    {
        playButton.interactable = false;
    }
}
