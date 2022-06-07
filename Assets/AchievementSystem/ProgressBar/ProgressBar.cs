using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    [SerializeField] int maxValue;
    [SerializeField] int startValue;
    [SerializeField] bool isInteractable;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxValue(maxValue);
        slider.interactable = isInteractable;
    }

    private void Update()
    {
         fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = startValue;

        fill.color = gradient.Evaluate(0f);
    }

    public void SetValue(int value)
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
