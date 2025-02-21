using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    [SerializeField] GameObject[] PassengerList;
    GameObject selectedPassenger;
    // Start is called before the first frame update
    void Start()
    {  
        for(int i = 0; i < 20; i++)
        {
            SelectPassenger();
        }
    }
    //Picks a random passenger to place an order, only picks one that isnt already chosen
    public void SelectPassenger()
    {
        selectedPassenger = PassengerList[Random.Range(0, PassengerList.Length)];
        if (selectedPassenger.GetComponent<Passenger>().getIsOrderActive() == false)
        {
            selectedPassenger.GetComponent<Passenger>().StartCoroutine(selectedPassenger.GetComponent<Passenger>().Order(60));
            Debug.Log(selectedPassenger);
        }
        else
        {
            Debug.Log("reroll");
            SelectPassenger();
        }
    }
    public void OrderComplete()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
