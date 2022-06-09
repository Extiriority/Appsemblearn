using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldSelection : MonoBehaviour
{
    [SerializeField] Outline outline;

    private void OnMouseEnter()
    {
        outline.enabled = true;
        FindObjectOfType<SelectionManager>().GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Outline>().gameObject.name;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
        FindObjectOfType<SelectionManager>().GetComponent<TextMeshProUGUI>().text = "";
    }

/*    private void OnMouseOver()
    {
        Debug.Log("over");
    }*/
}
