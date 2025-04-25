using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private int baseOrderTime = 100; //was 1.5 min (90)
    public static int numOrders = 3;
    public static List<GameObject> orderList = new List<GameObject> {};
    
    public static float survivalTime;
    // Start is called before the first frame update
    void Start()
    {  
        survivalTime = 0;
        AnnoyingPassenger.target = target;
        AnnoyingPassenger.bathroom = bathroom;
        SelectAnnoyingPassenger();
        StartCoroutine("passOnStart");
        
    }
    //Picks a random passenger to place an order, only picks one that isnt already chosen
    public void SelectPassenger()
    {
        selectedPassenger = PassengerList[Random.Range(0, PassengerList.Length)];
        if (!selectedPassenger.GetComponent<Passenger>().getIsOrderActive() && !selectedPassenger.GetComponent<Passenger>().getIsOnCooldown())
        {
            selectedPassenger.GetComponent<Passenger>().StartCoroutine(selectedPassenger.GetComponent<Passenger>().Order(setOrderTime()));
            orderList.Add(selectedPassenger);
            Debug.Log(selectedPassenger);
        }
        else
        {
            Debug.Log("reroll");
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
        orderList.RemoveAt(0);
        SelectPassenger();
        ordersCompleted++;

    }
    public void OrderFailed()
    {
        ordersFinished++;
        orderList.RemoveAt(0);
        SelectPassenger();
    }
    public float setOrderTime() 
    {
        float i = baseOrderTime * Mathf.Pow((0.05f * Random.Range(18, 19)), (int) (ordersFinished/4));
        return i;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ordersCompleted++;
        }
        survivalTime += Time.deltaTime;
    }
    private IEnumerator passOnStart() {
        for(int i = 0; i < numOrders; i++)
        {
            SelectPassenger();
            yield return new WaitForSeconds(Random.Range(2,8));
        }
        
    }
}
