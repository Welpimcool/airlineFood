using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveOld : MonoBehaviour //change to be a subclass of table
{
    private GameObject objHolding;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objHolding != null) {
            if (objHolding.GetComponent<Ingredient>().getCook()) {
                GetComponentInChildren<Ingredient>().addValue(Time.deltaTime);
            }
            if (GetComponentInChildren<Ingredient>().getState() >= 4) {
                Destroy(objHolding);
                Debug.Log("burned food, state:"+GetComponentInChildren<Ingredient>().getState());
            }
        }
    }

    public void placeItem(GameObject ingredient, float value) {
        objHolding = ingredient;
        objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
        objHolding.transform.position = body.transform.position;
        objHolding.transform.parent = body.transform;
        GetComponentInChildren<Ingredient>().setValue(value);
    }
    public object[] grabItem() {
        object[] a = {objHolding,GetComponentInChildren<Ingredient>().getValue()};
        objHolding = null;
        return a;
    }

    
}
