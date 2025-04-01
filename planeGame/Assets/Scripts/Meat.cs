using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Meat : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        // this.setScale(0.75f);
        this.setMaxValue(10);
        // this.setState(0);
        // this.setValue(0);
        this.setMaxState(3);
        GetComponentInChildren<Meter>().setMaxValue(this.getMaxValue());
        this.setCook(true);
        this.setName("Meat");
        this.setList(new string[] {"Plate"});
        } else {
            GetComponentInChildren<Meter>().hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            //cooking
            if (getCook()) {
                GetComponentInChildren<Meter>().setValue(getValue());
                if (getValue() >= getMaxValue())
                {
                    setValue(0);
                    setState(getState() + 1);
                    Debug.Log("state increased:" + getState());
                }
            }
        }
    }
}
