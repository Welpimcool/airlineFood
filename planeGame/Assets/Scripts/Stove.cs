using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Table
{
    // Start is called before the first frame update
    void Start()
    {
        setBody(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (getHolding() != null) {
            if (getHolding().GetComponent<Ingredient>().getCook()) {
                getHolding().GetComponentInChildren<Ingredient>().addValue(Time.deltaTime);
            }
            if (getHolding().GetComponentInChildren<Ingredient>().getState() > getHolding().GetComponentInChildren<Ingredient>().getMaxState()) {
                kill();
                Debug.Log("burned food, state:"+GetComponentInChildren<Ingredient>().getState());
            }
        }
    }
}
