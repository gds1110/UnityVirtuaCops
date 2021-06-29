using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ColorChange : MonoBehaviour, /*ISelectHandler,*/ IPointerEnterHandler, IPointerExitHandler
{
    Text text;

    void Start()
    {
        text = transform.GetComponentInChildren<Text>();
    }

    // When highlighted with mouse.
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.yellow;

        // Do something.
        //Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }
    // When selected.
    //public void OnSelect(BaseEventData eventData)
    //{
    //    // Do something.
    //    Debug.Log("<color=red>Event:</color> Completed selection.");
    //}
}
