using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D body;
    public int walkSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        body.velocity = direction.normalized * walkSpeed;
        
    }

    void FixedUpdate() 
    {
        body.velocity = direction * walkSpeed;
    }
}
