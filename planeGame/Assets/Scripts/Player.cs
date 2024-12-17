using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 inpDirection;
    private Rigidbody2D body;
    private GameObject objHolding;
    public LayerMask mask;
    public int walkSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        inpDirection = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        if (direction != Vector2.zero) {
            inpDirection = direction;
        }
        
        if (Input.GetKeyDown(KeyCode.E)) {
            pickup();
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            GetComponentInChildren<Ingredient>().addValue(1);
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            GetComponentInChildren<Ingredient>().subtractValue(1);
        }
    }

    void FixedUpdate() 
    {
        body.velocity = direction * walkSpeed;
        if (direction != Vector2.zero) {
            if (Input.GetAxisRaw("Horizontal") < 0) {
                body.rotation = Vector2.Angle(Vector2.up, inpDirection);
            } else if (Input.GetAxisRaw("Horizontal") > 0) {
                body.rotation = Vector2.Angle(Vector2.up, inpDirection) * -1;
            } else {
                if (Input.GetAxisRaw("Vertical") > 0) {
                    body.rotation = 0;
                } else if (Input.GetAxisRaw("Vertical") < 0) {
                    body.rotation = 180;
                }
            }
            
        }
        
    }
    void pickup() {
        RaycastHit2D hit = Physics2D.Raycast(body.position,inpDirection,3f,mask);
        Debug.DrawRay(body.position,inpDirection*3f,Color.red);
        Debug.Log("checking for object to pickup");
        
        if (hit) {

            Debug.Log("checking for spawner");
            if (hit.collider.GetComponent<IngredientSpawner>() != null) {
                Debug.Log("Hit something: "+hit.collider.name);
                if (objHolding != null) {
                    Destroy(objHolding);
                } else {
                    objHolding = hit.collider.GetComponent<IngredientSpawner>().onInteraction();
                    objHolding = Instantiate(objHolding, body.transform.position, body.transform.rotation);
                    holdItem(objHolding);
                }
            } 
            
            Debug.Log("checking for stove");
            if (hit.collider.GetComponent<Stove>() != null) {
                Debug.Log("Hit something: "+hit.collider.name);
                if (objHolding != null) {
                    hit.collider.GetComponent<Stove>().placeItem(objHolding, GetComponentInChildren<Ingredient>().getValue());
                    Destroy(objHolding);
                }
                else {
                    object[] list = hit.collider.GetComponent<Stove>().grabItem();
                    objHolding = (GameObject) list[0];
                    holdItem(objHolding);
                    GetComponentInChildren<Ingredient>().setValue((float) list[1]);
                }
            }

            Debug.Log("checking for table");
            if (hit.collider.GetComponent<Table>() != null) {
                Debug.Log("Hit something: "+hit.collider.name);
                if (objHolding != null) {
                    hit.collider.GetComponent<Table>().placeItem(objHolding);
                    Destroy(objHolding);
                }
                else {
                    objHolding = hit.collider.GetComponent<Table>().grabItem();
                    holdItem(objHolding);
                }
            }

        } else {
            Debug.Log("Nothing Found");
        }
        
        
        
    }
    void holdItem(GameObject item) {
        item.transform.position = body.transform.position;
        item.transform.position = new Vector3(item.transform.position.x+inpDirection.x,item.transform.position.y+inpDirection.y,0);
        item.transform.parent = body.transform;
        item.transform.localScale = new Vector3(0.5f,0.5f,0);
        item.transform.rotation = body.transform.rotation;
    }
}
