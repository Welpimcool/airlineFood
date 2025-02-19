using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ingredient : MonoBehaviour
{
    public bool prop = false;
    private float value = 0;
    public float maxValue = 10;
    public GameObject meter;
    private int state;
    public string[] combinationList;
    public string ingredientName;
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
    public string[] getList() {
        return combinationList;
    }
    public string getName() {
        return ingredientName;
    }
    private bool canCombine(GameObject ingredient) {
        string nm = ingredient.GetComponent<Ingredient>().getName();
        foreach (string i in combinationList) {
            if (i == nm) {
            return true;
            } 
        }
        return false;
    }
    public bool combine(GameObject ingredient) {
        if (canCombine(ingredient)) {
            Debug.Log("objects can combine :)");
            return true;
        } else {
            Debug.Log("objects cannot combine :(");
            return false;
        }
    }
    
}
