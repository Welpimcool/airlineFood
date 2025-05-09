using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] Animation playerL;
    [SerializeField] Animation playerR;
    [SerializeField] Animation playerU;
    [SerializeField] Animation playerD;
    private Vector3 offset = new Vector3(0,0.5f,0);
    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim =GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
        if (Input.GetAxisRaw("Vertical") > 0) {
            anim.Play("WalkingUp");
        } else if (Input.GetAxisRaw("Vertical") < 0) {
            // GetComponent<SpriteRenderer>().sprite = playerD;
        } else if(Input.GetAxisRaw("Horizontal") > 0) {
            // GetComponent<SpriteRenderer>().sprite = playerR;
        } else if(Input.GetAxisRaw("Horizontal") < 0) {
            // GetComponent<SpriteRenderer>().sprite = playerL;
        }
    }
}
