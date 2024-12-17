using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
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
            
        }
    }

    public void placeItem(GameObject ingredient) {
        objHolding = ingredient;
        objHolding = Instantiate(ingredient, body.transform.position, body.transform.rotation);
        objHolding.transform.position = body.transform.position;
    }
    public GameObject grabItem() {
        return objHolding;
    }
}
