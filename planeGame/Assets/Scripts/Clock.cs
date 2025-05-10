using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] GameObject img1;
    [SerializeField] GameObject img2;
    [SerializeField] GameObject img3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        img1.transform.rotation = Quaternion.Euler(0, 0, (float) -Mathf.Repeat(GameManager.currentDayTime, 360f));
        img2.transform.rotation = Quaternion.Euler(0, 0, (float) -Mathf.Repeat(GameManager.currentDayTime*6, 360f));
        img3.transform.rotation = Quaternion.Euler(0, 0, (float) -Mathf.Repeat(GameManager.currentDayTime*360, 360f));
        // Debug.Log("time: "+(float)Mathf.Repeat(GameManager.currentDayTime, 360f));
    }
}
