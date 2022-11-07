using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    public void SetMaxHealth(float value) 
    {
        slider.maxValue = value;
        slider.value = value;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float value) 
    {
        slider.value = value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
