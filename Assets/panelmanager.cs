using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class panelmanager : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Move the hovered object to the last sibling in the hierarchy
        transform.SetAsLastSibling();
    }
}
