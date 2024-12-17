using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public bool prop = false;
    private float value = 0;
    public float maxValue = 10;
    public GameObject meter;
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
            GetComponentInChildren<Meter>().setMaxValue(maxValue);
        } else {
            Destroy(meter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop) {
            GetComponentInChildren<Meter>().setValue(value);
        }
    }
    public void setValue(float inp) {
        value = inp;
    }
    public void addValue(float inp) {
        value += inp;
    }
    public void subtractValue(float inp) {
        value -= inp;
    }
    public float getValue() {
        return value;
    }
}
