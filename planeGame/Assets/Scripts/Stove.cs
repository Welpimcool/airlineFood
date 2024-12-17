using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    private GameObject objHolding;
    private Rigidbody2D body;
    private float objValue;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objHolding != null) {
            objValue += Time.deltaTime;
            GetComponentInChildren<Ingredient>().setValue(objValue);
        }
    }

    public void placeItem(GameObject ingredient, float value) {
        objHolding = ingredient;
        objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
        objHolding.transform.position = body.transform.position;
        objHolding.transform.parent = body.transform;
        GetComponentInChildren<Ingredient>().setValue(value);
        objValue = value;
    }
    public object[] grabItem() {
        object[] a = {objHolding,objValue};
        objHolding = null;
        return a;
    }
}
