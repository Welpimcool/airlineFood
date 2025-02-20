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

    public bool placeItem(GameObject ingredient, float value) {
        if (objHolding == null)
        {
            objHolding = ingredient;
            objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
            objHolding.transform.position = body.transform.position;
            objHolding.transform.parent = body.transform;
            GetComponentInChildren<Ingredient>().setValue(value);
            objValue = value;
            return true;
        }
        else 
        {
            //Add code for combining multiple ingredients
            bool didWork = objHolding.GetComponent<Ingredient>().combine(ingredient);
            if (didWork) {
                holdCombinedItem(ingredient);
                return true;
            } else {
                return false;
            }
        }
    }
    public object[] grabItem() {
        object[] a = {objHolding,objValue};
        objHolding = null;
        return a;
    }

    private void holdCombinedItem(GameObject ingredient) {
        string name1 = objHolding.GetComponent<Ingredient>().getName();
        name1 += " ";
        name1 += ingredient.GetComponent<Ingredient>().getName();
        // use .Contains() method to check for all the ingredients to find sprite to use
        // make a class that is a base for combined food, its only methods is combine more ingredients and serve
    }
}
