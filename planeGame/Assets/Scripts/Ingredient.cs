using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class Ingredient : MonoBehaviour
{
    public bool prop = false;
    private bool canCook = false;
    private float value = 0;
    public float maxValue = 10;
    public GameObject meter;
    private int state;
    private string[] combinationList;
    private string ingredientName;
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
        if (canCook) {
            GetComponentInChildren<Meter>().setValue(value);
            if (value >= maxValue)
            {
                setValue(0);
                setState(state + 1);
                Debug.Log("state increased:" + state);
            }
        }
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
    public void setList(string[] inp) {
        this.combinationList = inp;
    }
    public string getName() {
        return ingredientName;
    }
    public void setName(string inp) {
        ingredientName = inp;
    }
    public void setCook(bool a) {
        canCook = a;
    }
    private bool canCombine(GameObject ingredient) {
        string nm = ingredient.GetComponent<Ingredient>().getName();
        foreach (string i in this.combinationList) {
            if (i.Equals(nm)) {
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
