using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderMeter : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    void Update()
    {
        slider.value = GetComponentInParent<Passenger>().getTimeRemaining()/60;
    }
}
