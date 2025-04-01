using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private GameObject objHolding;
    private Rigidbody2D body;
    private float objValue;
    public GameObject food;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public object[] placeItem(GameObject ingredient) {
        if (objHolding == null)
        {
            // objHolding = ingredient;
            // Debug.Log("Instantiating object:"+ingredient+" as object "+this.name);
            objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
            
            objHolding.transform.position = body.transform.position;
            objHolding.transform.parent = body.transform;
<<<<<<< Updated upstream
            GetComponentInChildren<Ingredient>().setValue(value);
            objValue = value;
            return true;
=======
            objValue = ingredient.GetComponentInChildren<Ingredient>().getValue();
            objHolding.GetComponentInChildren<Ingredient>().setValue(objValue);
            objHolding.GetComponentInChildren<Ingredient>().setState(ingredient.GetComponentInChildren<Ingredient>().getState());
            object[] a = {true,objHolding};
            return a;
>>>>>>> Stashed changes
        }
        else 
        {
            //Add code for combining multiple ingredients
            bool didWork = objHolding.GetComponent<Ingredient>().combine(ingredient);
            if (didWork) {
                Debug.Log("Can combine, passing through "+ingredient.GetComponent<Ingredient>().getName());
                holdCombinedItem(ingredient);
                object[] t = {true};
                return t;
            } else {
                object[] f = {false};
                return f;
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
        string name2 = ingredient.GetComponent<Ingredient>().getName();


        // use .Contains() method to check for all the ingredients to find sprite to use
        // make a class that is a base for combined food, its only methods is combine more ingredients and serve



        //temp food placeholder
        

        Destroy(objHolding);
        objHolding = Instantiate(food);
        objHolding.transform.position = body.transform.position;
        objHolding.transform.parent = body.transform;

        objHolding.GetComponent<Food>().findSprite(new string[] {name1,name2});

        Debug.Log("spriteNum:"+objHolding.GetComponent<Food>().getSpriteNum());
    }
    public GameObject getHolding() {
        return objHolding;
    }
    public void setHolding(GameObject a) {//i dont know if this is needed
        objHolding = a;
    }
    public void kill() {
        Destroy(objHolding);
    }
    public void setBody(Rigidbody2D a) {
        body = a;
    }
    
        
}
