using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    [SerializeField] GameObject[] PassengerList;
    [SerializeField] GameObject[] annoyingPassengerList;
    [SerializeField] Transform target;
    [SerializeField] Transform bathroom;
    GameObject selectedPassenger;
    public static int ordersCompleted;
    public static int angryPassengers;
    private int ordersFinished;
    // Start is called before the first frame update
    void Start()
    {  
        AnnoyingPassenger.target = target;
        AnnoyingPassenger.bathroom = bathroom;
        SelectAnnoyingPassenger();
        for(int i = 0; i < 4; i++)
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
            selectedPassenger.GetComponent<Passenger>().StartCoroutine(selectedPassenger.GetComponent<Passenger>().Order(setOrderTime()));
            // Debug.Log(selectedPassenger);
        }
        else
        {
            // Debug.Log("reroll");
            SelectPassenger();
        }
    }
    public void SelectAnnoyingPassenger()
    {
        selectedPassenger = annoyingPassengerList[Random.Range(0, annoyingPassengerList.Length)];
        selectedPassenger.GetComponent<AnnoyingPassenger>().StartCoroutine(selectedPassenger.GetComponent<AnnoyingPassenger>().imWalkinEre());
        // Debug.Log(selectedPassenger);
    }
    public void OrderComplete()
    {
        ordersFinished++;
        SelectPassenger();
        ordersCompleted++;

    }
    public void OrderFailed()
    {
        ordersFinished++;
        SelectPassenger();
    }
    public float setOrderTime() 
    {
        float i = 60 * Mathf.Pow((0.05f * Random.Range(18, 19)), (int) (ordersFinished/4));
        return i;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ordersCompleted++;
        }
    }
}
