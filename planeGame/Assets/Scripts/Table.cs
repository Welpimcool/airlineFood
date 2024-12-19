using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
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
        
    }

    public void placeItem(GameObject ingredient, float value) {
        if (objHolding == null)
        {
            objHolding = ingredient;
            objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
            objHolding.transform.position = body.transform.position;
            objHolding.transform.parent = body.transform;
            GetComponentInChildren<Ingredient>().setValue(value);
            objValue = value;
        }
        else 
        {
            //Add code for combining multiple ingredients
        }
    }
    public object[] grabItem() {
        object[] a = {objHolding,objValue};
        objHolding = null;
        return a;
    }
}
