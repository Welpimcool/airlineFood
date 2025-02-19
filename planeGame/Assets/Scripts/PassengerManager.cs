using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    [SerializeField] GameObject[] PassengerList; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject testing = PassengerList[Random.Range(0, 20)];
        testing.GetComponentInChildren<Passenger>().test();
        Debug.Log(testing);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
