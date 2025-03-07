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
        this.setState(0);
        this.setValue(0);
        this.setCook(true);
        this.setName("Fish");
        this.setList(new string[] {"Plate"});
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
