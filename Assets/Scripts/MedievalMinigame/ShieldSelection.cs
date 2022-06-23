using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using CamSystem;

public class ShieldSelection : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Outline outline;

    [Header("Shield Selection In Workshop")]
    [SerializeField] bool canBeSelectedInWorkshop;
    [SerializeField] public GameObject shield;

    [SerializeField] GameObject leftUI;
    [SerializeField] GameObject rightUI;

    [SerializeField] TextMeshProUGUI text;
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
            leftUI.SetActive(true);
            rightUI.SetActive(true);

            SoundManager.instance.play("ShieldSelect");
            text.text = this.gameObject.name;
            GameObject.FindObjectOfType<CameraAnchorManager>().ActivatePreviousAnchor();
        }
        

    }

    /*    private void OnMouseOver()
        {
            Debug.Log("over");
        }*/
}
