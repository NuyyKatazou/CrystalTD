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

    public static bool tutorialEnd = false;

    public PlayMenu playMenu;
    private string version;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();

        levelWindow.SetLevelSystem(levelSystem);
    }
    
        private void Start()
    {
        versionText.text = Application.version;
    }

    public void PlayButton()
    {
        if (tutorialEnd == false){
            ChangeScene("TutorialLevel");
        }
        if (tutorialEnd == true){
            playMenu.OpenPlayCanvas();
            CloseMenuCanvas();
        }
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
}
