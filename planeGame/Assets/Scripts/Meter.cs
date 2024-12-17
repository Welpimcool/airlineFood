using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    public Image fill;
    public void setValue(float value) {
        Slider.value = value;
        fill.color = gradient.Evaluate(Slider.normalizedValue);
    }
    public void setMaxValue(float value) {
        Slider.maxValue = value;
        Slider.value = 0;
        fill.color = gradient.Evaluate(0f);
    }
}
