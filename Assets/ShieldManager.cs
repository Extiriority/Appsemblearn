using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] private MeshFilter modelYouWantToChange;
    public void ChangeColor(GameObject data)
    {
        GameObject.FindGameObjectWithTag("Color").GetComponent<Renderer>().material.color = data.GetComponent<DragDrop>().shield.color;
    }

    public void ChangeShieldType(GameObject data)
    {
        modelYouWantToChange.mesh = data.GetComponent<DragDrop>().shield.shieldType;
    }
}
