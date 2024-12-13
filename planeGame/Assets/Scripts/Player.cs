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
    }

    void FixedUpdate() 
    {
        body.velocity = direction * walkSpeed;
        if (direction != Vector2.zero) {
            if (Input.GetAxisRaw("Horizontal") < 0) {
                body.rotation = Vector2.Angle(Vector2.up, direction);
            } else {
                body.rotation = Vector2.Angle(Vector2.up, direction) * -1;
            }
            
        }
        
    }
    void pickup() {
        RaycastHit2D hit = Physics2D.Raycast(body.position,inpDirection,3f,mask);
        Debug.DrawRay(body.position,inpDirection*3f,Color.yellow);
        if (hit.collider.GetComponent<IngredientSpawner>() != null) {
            Debug.Log("Hit something: "+hit.collider.name);
            objHolding = hit.collider.GetComponent<IngredientSpawner>().onInteraction();
            objHolding = Instantiate(objHolding, body.transform.position, body.transform.rotation);
            objHolding.transform.position = body.transform.position;
            objHolding.transform.position = new Vector3(objHolding.transform.position.x+inpDirection.x,objHolding.transform.position.y+inpDirection.y,0);
            objHolding.transform.parent = body.transform;
        }

    }
}
