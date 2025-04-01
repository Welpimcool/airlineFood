using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    public Slider Slider;
    public Gradient gradient;
    public Image fill;
    // public SpriteRenderer sp;
    public Image border;
    public void setValue(float value) {
        // Debug.Log("meter value updated to "+value);
        // if (value == 0 && Slider.value != 0) {
        //     // Debug.Log("value set to 0 from "+Slider.value);
        // }
        Slider.value = value;
        fill.color = gradient.Evaluate(Slider.normalizedValue);
    }
    public void setMaxValue(float value) {
        // Debug.Log("max value set to "+value+", value was "+Slider.value,this);
        float temp = Slider.value;
        if (Slider.maxValue != value) {
            Slider.maxValue = value;
            Slider.value = temp;
            fill.color = gradient.Evaluate(0f);
        }
        
    }
    public void hide() {
        fill.enabled = false;
        border.enabled = false;
    }
    public void show() {
        fill.enabled = true;
        border.enabled = true;
    }
}
