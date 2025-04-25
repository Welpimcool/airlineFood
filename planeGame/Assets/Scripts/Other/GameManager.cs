using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] orderSheets;
    [SerializeField] GameObject canvas;
    
    public static int day;
    public static bool isEndless;
    private List<GameObject> orderList;
    // Start is called before the first frame update
    public static void lose()
    {
        Debug.Log("you lose");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        day = 1;
        isEndless = true;
        for (int i = 0; i < PassengerManager.numOrders; i++) {
            orderSheets[i].GetComponent<OrderSheet>().DispSprite("");
            orderSheets[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        orderList = PassengerManager.orderList;
        
        for (int i = 0; i < PassengerManager.numOrders; i++) {
            if (orderList.Count > i) {
                if (orderList[i].GetComponent<Passenger>().getOrderedFood() != "") {
                    orderSheets[i].GetComponent<OrderSheet>().DispSprite(orderList[i].GetComponent<Passenger>().getOrderedFood());
                    orderSheets[i].SetActive(true);
                }
                

            }
        }
    }
}
