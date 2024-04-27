using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject defeatCanvas;

    private void Update()
    {
        if (LevelManager.main.gameLose == true)
        {
            UIManager.main.SetHoveringState(true);
        }
        else
        {
            UIManager.main.SetHoveringState(false);
        }
    }

    public void DefeatButton()
    {
        // Save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        ChangeScene("MainMenu");
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OpenDefeatCanvas()
    {
        defeatCanvas.SetActive(true);
    }

    public void CloseDefeatCanvas()
    {
        defeatCanvas.SetActive(false);
    }
}