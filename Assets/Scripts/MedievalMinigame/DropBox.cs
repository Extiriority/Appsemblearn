using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBox : MonoBehaviour, IDropHandler
{
    public ShieldManager Shield;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            GetComponentInChildren<TextMeshProUGUI>().text = eventData.pointerDrag.GetComponent<DragDrop>().shield.color.ToString();
        }

        Shield.ChangeColor(eventData.pointerDrag.gameObject);
        Shield.ChangeShieldType(eventData.pointerDrag.gameObject);
    }
}
