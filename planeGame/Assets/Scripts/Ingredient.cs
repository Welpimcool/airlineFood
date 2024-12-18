using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public bool prop = false;
    private float value = 0;
    public float maxValue = 10;
    public GameObject meter;
    private int state;
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
            GetComponentInChildren<Meter>().setMaxValue(maxValue);
            state = 0;
        } else {
            Destroy(meter);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop) {
            GetComponentInChildren<Meter>().setValue(value);
            if (value >= maxValue) {
                value = 0;
                state += 1;
                Debug.Log("state increased:"+state);
            }

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
    public int getState() {
        return state;
    }
    public void setState(int inp) {
        state = inp;
    }
}
