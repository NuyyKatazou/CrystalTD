using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject optionsCanvas;

    public void ExitButton()
    {
        CloseOptionsCanvas();
    }

    public void OpenOptionsCanvas()
    {
        optionsCanvas.SetActive(true);
    }

    public void CloseOptionsCanvas()
    {
        optionsCanvas.SetActive(false);
    }
}
