using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        this.setState(0);
        this.setValue(0);
        this.setCook(false);
        this.setName("Plate");
        this.setScale(1);
        this.setList(new string[] {"Meat"});
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            
        }
    }
}
