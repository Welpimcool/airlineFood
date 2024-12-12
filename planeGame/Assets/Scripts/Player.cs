using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 inpDirection;
    private Rigidbody2D body;
    private GameObject objHolding;
    public string interactionTag = "Interactable";
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

        body.velocity = direction.normalized * walkSpeed;
        
        if (Input.GetKey(KeyCode.E)) {
            pickup();
        }
    }

    void FixedUpdate() 
    {
        body.velocity = direction * walkSpeed;
    }
    void pickup() {

        RaycastHit2D hit = Physics2D.Raycast(body.position,inpDirection,10f);
        Debug.DrawRay(body.position,inpDirection*10f,Color.yellow);
        if (hit) {
            if (hit.collider.CompareTag(interactionTag)) {
                Debug.Log("Hit something: "+hit.collider.name);
            }
            
        }

    }
}
