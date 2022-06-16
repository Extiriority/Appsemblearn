using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ShieldSelection : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Outline outline;

    [Header("Shield Selection In Workshop")]
    [SerializeField] bool canBeSelectedInWorkshop;
    [SerializeField] public GameObject shield;

    Shield Shield;

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;

        if(!canBeSelectedInWorkshop)
            FindObjectOfType<SelectionManager>().GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Outline>().gameObject.name;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;

        if(!canBeSelectedInWorkshop)
            FindObjectOfType<SelectionManager>().GetComponent<TextMeshProUGUI>().text = "";
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canBeSelectedInWorkshop)
        {
            Shield = FindObjectOfType<Shield>();
            Shield.ChangeShieldType(gameObject);
        }
        

    }

    /*    private void OnMouseOver()
        {
            Debug.Log("over");
        }*/
}
