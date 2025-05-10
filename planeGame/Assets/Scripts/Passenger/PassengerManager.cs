using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassengerManager : MonoBehaviour
{
    [SerializeField] GameObject[] PassengerList;
    // [SerializeField] GameObject[] annoyingPassengerList;
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
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            survivalTime = 0;
            AnnoyingPassenger.target = target;
            AnnoyingPassenger.bathroom = bathroom;
            SelectAnnoyingPassenger();
            StartCoroutine("passOnStart");
        } else {
            foreach(GameObject i in PassengerList) {
                i.GetComponent<Passenger>().disable();
                // i.SetActive(false);
            }
        }
        
    }
    //Picks a random passenger to place an order, only picks one that isnt already chosen
    public void SelectPassenger()
    {
        selectedPassenger = PassengerList[Random.Range(0, PassengerList.Length)];
        if (!selectedPassenger.GetComponent<Passenger>().getIsOrderActive() && !selectedPassenger.GetComponent<Passenger>().getIsOnCooldown() && !selectedPassenger.GetComponent<Passenger>().getIsWalking())
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
        selectedPassenger = PassengerList[Random.Range(0, PassengerList.Length)]; //.GetComponent<Passenger>().getAnnoyingPassenger()
        if (!(selectedPassenger.GetComponent<Passenger>().getIsWalking() || selectedPassenger.GetComponent<Passenger>().getIsOnCooldown() || selectedPassenger.GetComponent<Passenger>().getIsOrderActive())) { //if they are not walking or ordering or on cooldown
            selectedPassenger.GetComponent<Passenger>().setIsWalking(true);
            selectedPassenger.GetComponent<Passenger>().getAnnoyingPassenger().GetComponent<AnnoyingPassenger>().StartCoroutine(selectedPassenger.GetComponent<Passenger>().getAnnoyingPassenger().GetComponent<AnnoyingPassenger>().imWalkinEre(this));
        } else {
            SelectAnnoyingPassenger();
        }
        
        
        
        
        // Debug.Log(selectedPassenger);
    }
    public void OrderComplete(GameObject pass)
    {
        ordersFinished++;
        orderList.Remove(pass);
        ordersCompleted++;
        StartCoroutine("waitForNewPass");

    }
    public void OrderFailed(GameObject pass)
    {
        ordersFinished++;
        orderList.Remove(pass);
        StartCoroutine("waitForNewPass");
    }
    public float setOrderTime() 
    {
        float i = baseOrderTime * Mathf.Pow(0.05f * Random.Range(18, 19),ordersFinished/4);
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
        yield return new WaitForSeconds(Random.Range(5,15));
        for(int i = 0; i < numOrders; i++)
        {
            SelectPassenger();
            yield return new WaitForSeconds(Random.Range(2,8));
        }
    }
    private IEnumerator waitForNewPass() {
        yield return new WaitForSeconds(Random.Range(2,8));
        SelectPassenger();
    }
}
