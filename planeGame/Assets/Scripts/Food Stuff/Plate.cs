using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Ingredient
{
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        setScale(1);
        setState(0);
        setValue(0);
        setCook(false);
        setCut(false);
        setName("Plate");
        setList(new string[] {"Bun","1Meat Bun","1Meat Bun 1Cheese","Bun 1Cheese"});
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
