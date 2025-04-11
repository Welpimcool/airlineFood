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

    public bool placeItem(GameObject ingredient, float value) {
        if (objHolding == null)
        {
            // objHolding = ingredient;
            // Debug.Log("Instantiating object:"+ingredient+" as object "+this.name);
            objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
            objHolding.transform.position = body.transform.position;
            objHolding.transform.parent = body.transform;
            objHolding.GetComponentInChildren<Ingredient>().setValue(value);
            objHolding.GetComponentInChildren<Ingredient>().setState(ingredient.GetComponentInChildren<Ingredient>().getState());
            objHolding.GetComponentInChildren<Ingredient>().setName(ingredient.GetComponentInChildren<Ingredient>().getName());
            objValue = value;
            // Debug.Log("place state:"+objHolding.GetComponentInChildren<Ingredient>().getState());
            return true;
        }
        else 
        {
            //Add code for combining multiple ingredients
            bool didWork = objHolding.GetComponent<Ingredient>().combine(ingredient);
            if (didWork) {
                Debug.Log("Can combine, passing through "+ingredient.GetComponent<Ingredient>().getName());
                holdCombinedItem(ingredient);
                return true;
            } else {
                return false;
            }
        }
    }
    public object[] grabItem() {
        object[] a = {objHolding,objHolding.GetComponent<Ingredient>().getValue(),objHolding.GetComponent<Ingredient>().getState()};
        objHolding = null;
        return a;
    }

    private void holdCombinedItem(GameObject ingredient) {
        string name1 = objHolding.GetComponent<Ingredient>().getName();
        string name2 = ingredient.GetComponent<Ingredient>().getName();

        Destroy(objHolding);
        objHolding = Instantiate(food);
        objHolding.transform.position = body.transform.position;
        objHolding.transform.parent = body.transform;

        string str = objHolding.GetComponent<Food>().findSprite(new string[] {name1,name2});
        if (str != "") {
            objHolding.GetComponent<Food>().setName(str);
        }

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
