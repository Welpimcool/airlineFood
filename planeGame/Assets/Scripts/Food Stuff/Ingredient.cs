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
    private bool canCut = false;
    public Sprite[] stateSprite;
    Dictionary<String, int> spriteDict = new()
    {
        ["Food"] = 0,
        ["1Meat Plate"] = 1,
        ["1Meat Bun"] = 2,
        ["Bun Plate"] = 3,
        ["1Meat Bun Plate"] = 4
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
        // Debug.Log("added "+inp+" to value, new total is :"+value);
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
        // Debug.Log("name set to "+inp+" from "+ingredientName);
        ingredientName = inp;
    }
    public void setCook(bool a) {
        canCook = a;
    }
    public bool getCook() {
        return canCook;
    }
    public void setCut(bool a) {
        canCut = a;
    }
    public bool getCut() {
        return canCut;
    }
    public Dictionary<string, int> getSpriteList() {
        return spriteDict;
    }
    public float getScale() {
        // Debug.Log("Getting scale:"+scale, gameObject);
        return scale;
    }
    public void setScale(float inp) {
        scale = inp;
        // Debug.Log("Setting scale:"+scale, gameObject);
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
    public Sprite getStateSprite(int a) {
        return stateSprite[a];
    }
    public void setStateSprite(Sprite[] a) {
        stateSprite = a;
    }
    private bool canCombine(GameObject ingredient) {//change to not need exact orders (meat plate vs plate meat)
        string nm = ingredient.GetComponent<Ingredient>().getName() +" "+ this.getName();
        string temp;
        
        foreach (string i in spriteDict.Keys) { //for each food
            Debug.Log("looking through string:"+nm);
            temp = nm;
            foreach(string j in i.Split(" ")) {
                Debug.Log("removing instances of "+j);
                temp = temp.Replace(j,""); //remove instances of the food ingredients from the name
                Debug.Log("new string: "+temp);
            }
            temp = temp.Replace(" ","");
            Debug.Log("turned string: "+nm+" into string: "+temp);
             if (temp.Equals("")) {
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
