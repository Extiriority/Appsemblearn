using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    private Vector3 startingPos;

    [Header("Type")]
    [SerializeField] public Types dropboxType = new Types();


    [Header("Shield Properties")]
    [SerializeField] public GameObject shield;
    [SerializeField] public Color color;
    [SerializeField] public GameObject icon;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        startingPos = rectTransform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        rectTransform.localPosition = startingPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SoundManager.instance.play("PickupOption");
    }
}
