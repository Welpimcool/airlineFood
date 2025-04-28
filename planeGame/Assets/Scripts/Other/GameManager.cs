using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] orderSheets;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject dayMeter;
    
    public static int day = 1;
    public static bool isEndless;
    private List<GameObject> orderList;
    public static float dayTime = 270f;
    public float currentDayTime;
    // Start is called before the first frame update
    public static void lose()
    {
        Debug.Log("you lose");
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        
    }
    void Start()
    {
        isEndless = false; //was true
        currentDayTime = 0f;
        if (SceneManager.GetActiveScene().buildIndex != 3) {
           for (int i = 0; i < PassengerManager.numOrders; i++) {
            orderSheets[i].GetComponent<OrderSheet>().DispSprite("");
            orderSheets[i].SetActive(false);
            } 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3) { //if in a day
            currentDayTime += Time.deltaTime;
            orderList = PassengerManager.orderList;
            if (currentDayTime < dayTime) { //if day is running, add logic for delays (earthquake)
                for (int i = 0; i < PassengerManager.numOrders; i++) {
                    if (orderList.Count > i) {
                        if (orderList[i].GetComponent<Passenger>().getOrderedFood() != "") {
                            orderSheets[i].GetComponent<OrderSheet>().DispSprite(orderList[i].GetComponent<Passenger>().getOrderedFood());
                            orderSheets[i].SetActive(true);
                        }
                    }
                }
            } else { //day ended
                day += 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load into transition, later make transition go to after day
            }
        } else { //After-Day
            //  enable/control upgrades
            //  give a way to exit to a normal day
        }
        
       
    }
}
