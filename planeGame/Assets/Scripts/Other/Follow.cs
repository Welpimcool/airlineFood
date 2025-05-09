using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject target;
    private Vector3 offset = new Vector3(0,0.5f,0);
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
        anim.SetFloat("Speed X", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Speed Y", Input.GetAxisRaw("Vertical"));
    }
}
