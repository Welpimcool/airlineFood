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
    public string ingredientName = "";
    public string[] combineList = {};
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
        //cooking
    }
    public void setValue(float inp) {
        value = inp;
    }
    public void addValue(float inp) {
        value += inp;
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
    public string getName() {
        return ingredientName;
    }
    public bool canCombine(GameObject ingredient) {
        string nm = ingredient.GetComponent<Ingredient>().getName();
        foreach(string i in combineList) {
            if (i == nm) {
                return true;
            }
        }
        return false;
        
    }

    public void combine(GameObject ingredient) {
        if (canCombine(ingredient)) {
            //base code
            //impliment food object that this will create
        }
        // if both food cannot combine
    }
}
