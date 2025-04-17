using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Bun : Ingredient
{
    // [SerializeField] public Sprite[] stateSprites;
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        setScale(1);
        setState(0);
        setValue(0);
        setCook(false);
        setCut(false);
        setName("Bun");
        setList(new string[] {"Plate","1Meat","1Meat Plate","1Meat 1Cheese Plate","1Cheese Plate","1Cheese","1Meat 1Cheese"});
        // setStateSprite(stateSprites);
        } else {
            GetComponentInChildren<Meter>().hide();
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
