using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateModelWithSlider : MonoBehaviour
{
    [SerializeField] public GameObject rotatedObject;
    [SerializeField] Slider slider;

    private void Update()
    {
        if (rotatedObject != null)
        {
            rotatedObject.transform.rotation = Quaternion.Euler(0f, slider.value, 0f);
        }
    }
}
