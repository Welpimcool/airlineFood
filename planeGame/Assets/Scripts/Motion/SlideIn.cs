using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIn : MonoBehaviour
{
    public Vector3 endPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPosition, 4*Time.deltaTime);
    }
}
