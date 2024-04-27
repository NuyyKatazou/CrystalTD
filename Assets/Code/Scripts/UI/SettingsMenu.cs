using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject settingsCanvas;

    public void ExitButton()
    {
        CloseSettingsCanvas();
    }

    public void OpenSettingsCanvas()
    {
        settingsCanvas.SetActive(true);
    }

    public void CloseSettingsCanvas()
    {
        settingsCanvas.SetActive(false);
    }
}