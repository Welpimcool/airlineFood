using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        // this.setScale(0.75f);
        this.setMaxValue(10);
        // this.setState(0);
        // this.setValue(0);
        this.setMaxState(2);
        GetComponentInChildren<Meter>().setMaxValue(this.getMaxValue());
        this.setCook(true);
        this.setName("Fish");
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
