using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Color").GetComponent<Renderer>().material.color = GetComponentInParent<ShieldManager>().currentColor;
    }

    public void ChangeColor(GameObject data)
    {
        GameObject.FindGameObjectWithTag("Color").GetComponent<Renderer>().material.color = data.GetComponent<DragDrop>().color;
        GetComponentInParent<ShieldManager>().currentColor = data.GetComponent<DragDrop>().color;
    }

    public void ChangeShieldType(GameObject data)
    {
        this.gameObject.SetActive(false);
        data.GetComponent<DragDrop>().shield.SetActive(true);
    }
}
