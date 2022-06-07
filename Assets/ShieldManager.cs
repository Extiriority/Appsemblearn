using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public void ChangeColor(GameObject data)
    {
        this.GetComponent<MeshRenderer>().material.color = data.GetComponent<DragDrop>().data;
    }
}
