using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBox : MonoBehaviour, IDropHandler
{
    Shield Shield;
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Shield = FindObjectOfType<Shield>();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
            DragDrop dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

            if (dragDrop.shield != null)
            {
                GetComponentInChildren<TextMeshProUGUI>().text = eventData.pointerDrag.GetComponent<DragDrop>().shield.name;
                Shield.ChangeShieldType(eventData.pointerDrag.gameObject);
            }
            else
            {
                GetComponentInChildren<TextMeshProUGUI>().text = "#" + ColorUtility.ToHtmlStringRGB( eventData.pointerDrag.GetComponent<DragDrop>().color);
                Shield.ChangeColor(eventData.pointerDrag.gameObject);
            }

        }

       
       
    }
}
