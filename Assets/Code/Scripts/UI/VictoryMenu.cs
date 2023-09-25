using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject victoryCanvas;

    private void Update()
    {
        if (LevelManager.main.gameWin == true)
        {
            UIManager.main.SetHoveringState(true);
        }
        else
        {
            UIManager.main.SetHoveringState(false);
        }
    }

    public void VictoryButton()
    {
        ChangeScene("MainMenu");
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OpenVictoryCanvas()
    {
        victoryCanvas.SetActive(true);
    }

    public void CloseVictoryCanvas()
    {
        victoryCanvas.SetActive(false);
    }
}
