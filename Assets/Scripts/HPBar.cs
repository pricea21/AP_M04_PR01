using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
        GetComponentInParent<IHealth>().OnHPPctHealerChanged += HandleHPPctChanged;
    }

    private void HandleHPPctChanged(float pct)
    {
        slider.value = pct;
    }
}
