using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        this.setScale(1);
        this.setState(0);
        this.setValue(0);
        this.setCook(false);
        this.setName("Plate");
        this.setList(new string[] {"0Meat","0Fish","1Meat","1Fish"});
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            
        }
    }
}
