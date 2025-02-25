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
        this.setState(0);
        this.setValue(0);
        this.setCook(true);
        this.setScale(1);
        this.setName("Meat");
        this.setList(new string[] {"Plate"});
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            // cooking code moved to ingredient
        }
    }
}
