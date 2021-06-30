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
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }
}
