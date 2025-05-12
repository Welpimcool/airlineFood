using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cheese : Ingredient
{
    // [SerializeField] public Sprite[] stateSprites;
    // Start is called before the first frame update
    void Start()
    {
        if (!prop) {
        setMaxValue(1.75f);
        setMaxState(1);
        setScale(1);
        if (GetComponentInChildren<Meter>() != null) {
            GetComponentInChildren<Meter>().setMaxValue(getMaxValue());
        }
        // setState(0);
        // setValue(0);
        setCook(false);
        setCut(true);
        setName(getState()+"Cheese");
        setList(new string[] {"1Meat Bun Plate","1Meat Bun","Bun","Bun Plate"});
        } else {
            GetComponentInChildren<Meter>().hide();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!prop)
        {
            if (GetComponentInChildren<Meter>() != null) {
                GetComponentInChildren<Meter>().setValue(getValue());
                // Debug.Log("Value: "+getValue());
                if (getValue() >= getMaxValue())
                {
                    setValue(0);
                    setState(getState() + 1);
                    Debug.Log("state increased:" + getState());
                    setName(getState()+"Cheese");
                    Debug.Log("new name: "+getName());
                    if (getState() <= getMaxState()) {
                        GetComponent<SpriteRenderer>().sprite = getStateSprite(getState());
                    }
                }
            }
            
            
        }
    }
}
