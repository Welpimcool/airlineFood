using System;
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
    private int maxState;
    private string[] combinationList;
    private string ingredientName;
    public float scale;
    Dictionary<String, int> spriteDict = new()
    {
        ["Food"] = 0,
        ["Meat Plate"] = 1,
        ["Fish Plate"] = 2
        // [""] = 3,
        // [""] = 4,
        // [""] = 5
    };
    // Start is called before the first frame update
    void Start()
    {
        // // meter = GetComponentInChildren<Meter>();
        // scale = 1;
        // if (!prop && !canCook) {
        //     GetComponentInChildren<Meter>().setMaxValue(maxValue); // max value not correctly set, resets value once picked up
        //     state = 0;
        // } else {
        //     Destroy(meter); //idk if this works anymore
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // //cooking
        // if (canCook) {
        //     GetComponentInChildren<Meter>().setValue(value);
        //     if (value >= maxValue)
        //     {
        //         setValue(0);
        //         setState(state + 1);
        //         Debug.Log("state increased:" + state);
        //     }
        // }
    }
    public void setValue(float inp) {
        value = inp;
    }
    public void addValue(float inp) {
        value += inp;
        Debug.Log("added "+inp+" to value, new total is :"+value);
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
        combinationList = inp;
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
    public bool getCook() {
        return canCook;
    }
    public Dictionary<string, int> getSpriteList() {
        return spriteDict;
    }
    public float getScale() {
        Debug.Log("Getting scale:"+scale, gameObject);
        return scale;
    }
    public void setScale(float inp) {
        scale = inp;
        Debug.Log("Setting scale:"+scale, gameObject);
    }
    public GameObject getMeter(){
        return meter;
    }
    public float getMaxValue() {
        return maxValue;
    }
    public void setMaxValue(float a) {
        maxValue = a;
    }
    public int getMaxState() {
        return maxState;
    }
    public void setMaxState(int a) {
        maxState = a;
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
