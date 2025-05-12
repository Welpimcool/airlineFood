using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static int diff;
    // Start is called before the first frame update
    void Start()
    {
        diff = 3;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void upDiff() {
        diff += 1;
    }
    public void downDiff() {
        diff -= 1;
    }
}
