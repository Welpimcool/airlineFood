using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        this.setState(0);
        this.setValue(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            GetComponentInChildren<Meter>().setValue(this.getValue());
            if (this.getValue() >= maxValue)
            {
                this.setValue(0);
                this.setState(this.getState() + 1);
                Debug.Log("state increased:" + this.getState());
            }

        }
    }
}
