
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeValueSlider: MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;
    [SerializeField] private Slider slider;

    public float Value => value;

    private float value = 1f;

    public void OnValueChange()
    {
        textDisplay.text = $"{Mathf.Ceil(slider.value * 100)}%";
        value = slider.value;
    }

    public void InstiateValue(float value)
    {
        slider.value = value;
        OnValueChange();
        
    }
}

