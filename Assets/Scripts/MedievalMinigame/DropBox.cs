using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropBox : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Types dropboxType = new Types();
    [SerializeField] Texture2D blockedCursor;

    Shield Shield;

    public void OnDrop(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        if (eventData.pointerDrag != null)
        {
            DragDrop dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
            
            if(dragDrop.dropboxType.ToString() == this.dropboxType.ToString())
            {
                Shield = FindObjectOfType<Shield>();
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = this.GetComponent<RectTransform>().anchoredPosition;
                SoundManager.instance.play("DropInsideBox");


                if (dragDrop.shield != null)
                {
                    GetComponentInChildren<TextMeshProUGUI>().text = eventData.pointerDrag.GetComponent<DragDrop>().shield.name;
                    Shield.ChangeShieldType(eventData.pointerDrag.gameObject);
                }
                else
                {
                    GetComponentInChildren<TextMeshProUGUI>().text = "#" + ColorUtility.ToHtmlStringRGB(eventData.pointerDrag.GetComponent<DragDrop>().color);
                    Debug.Log(Shield.gameObject.name);
                    Shield.ChangeColor(eventData.pointerDrag.gameObject);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        DragDrop dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

        if (dragDrop.dropboxType.ToString() != this.dropboxType.ToString())
            Cursor.SetCursor(blockedCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

public enum Types
{
    Shield,
    Color,
    Icon
};
