using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDwn : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, 1.15f + Mathf.Sin(Time.timeSinceLevelLoad*2)/5, 0);
    }
}
