using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject playCanvas;

    public MainMenuController mainMenu;

    public void ExitButton()
    {
        ClosePlayCanvas();
        mainMenu.OpenMenuCanvas();
    }

    public void OpenPlayCanvas()
    {
        playCanvas.SetActive(true);
    }

    public void ClosePlayCanvas()
    {
        playCanvas.SetActive(false);
    }
}