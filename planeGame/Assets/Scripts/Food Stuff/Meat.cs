using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Meat : Ingredient
{
    // [SerializeField] public Sprite[] stateSprites;
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        setMaxValue(10);
        setMaxState(1);
        GetComponentInChildren<Meter>().setMaxValue(getMaxValue());
        setCook(true);
        setCut(false);
        setName(getState()+"Meat");
        setList(new string[] {"Plate","Bun","Bun Plate","Bun 1Cheese Plate","Bun 1Cheese"});
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
            //cooking
            if (getCook()) {
                GetComponentInChildren<Meter>().setValue(getValue());
                if (getValue() >= getMaxValue())
                {
                    setValue(0);
                    setState(getState() + 1);
                    Debug.Log("state increased:" + getState());
                    setName(getState()+"Meat");
                    GetComponent<SpriteRenderer>().sprite = getStateSprite(getState());
                }
            }
        }
    }
}
