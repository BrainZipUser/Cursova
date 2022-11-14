using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    [SerializeField] private Slider HealthSlider;
    [SerializeField] private Gradient HealthGradient;
    [SerializeField] private Image HealthFill;

    [SerializeField] private Slider ShieldSlider;
    [SerializeField] private Gradient ShieldGradient;
    [SerializeField] private Image ShieldFill;

    public void SetMaxHealth(float value) 
    {
        HealthSlider.maxValue = value;
        HealthSlider.value = value;

        HealthFill.color = HealthGradient.Evaluate(1f);
    }

    public void SetHealth(float value) 
    {
        HealthSlider.value = value;

        HealthFill.color = HealthGradient.Evaluate(HealthSlider.normalizedValue);
    }

    public void SetMaxShield(float value)
    {
        ShieldSlider.maxValue = value;
        ShieldSlider.value = value;

        ShieldFill.color = ShieldGradient.Evaluate(1f);
    }

    public void SetShield(float value)
    {
        ShieldSlider.value = value;

        ShieldFill.color = ShieldGradient.Evaluate(ShieldSlider.normalizedValue);
    }
}
