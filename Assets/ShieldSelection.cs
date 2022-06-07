using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSelection : MonoBehaviour
{
    [SerializeField] Outline outline;

    private void OnMouseEnter()
    {
        outline.enabled = true;
       
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

/*    private void OnMouseOver()
    {
        Debug.Log("over");
    }*/
}
