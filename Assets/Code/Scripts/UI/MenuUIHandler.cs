using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuUIHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static bool mouse_over = false;

    public void OnPointerEnter(PointerEventData enventData)
    {
        mouse_over = true;
        UIManager.main.SetHoveringState(true);
    }

    public void OnPointerExit(PointerEventData enventData)
    {
        mouse_over = false;
        UIManager.main.SetHoveringState(false);
    }
}