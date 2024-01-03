using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool select = false;
    public void OnPointerEnter(PointerEventData data)
    {
        select = true;
    }
    public void OnPointerExit(PointerEventData data)
    {
        select = false;
    }
}
