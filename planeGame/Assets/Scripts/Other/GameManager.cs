using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] orderSheets;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject dayMeter;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject player;    
    public static int day = 1;
    public static bool isEndless;
    private List<GameObject> orderList;
    public static float dayTime = 100f;
    public static float currentDayTime;
    public static bool isPaused = false;
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
        menu.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 1) {
           for (int i = 0; i < PassengerManager.numOrders; i++) {
            orderSheets[i].GetComponent<OrderSheet>().DispSprite("");
            orderSheets[i].SetActive(false);
            } 
            if (!isEndless) {
            dayMeter.GetComponent<Meter>().setMaxValue(dayTime);
            }
        } else {
            dayMeter.SetActive(false);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Unpause();
            } else {
                Pause();
            }
        }

        if (!isPaused) {

            if (Input.GetKeyDown(KeyCode.Period)) {
                currentDayTime += 30;
            } else if (Input.GetKeyDown(KeyCode.Comma)) {
                currentDayTime -= 30;
            }

            if (SceneManager.GetActiveScene().buildIndex == 1) { //if in a day
                currentDayTime += Time.deltaTime;
                dayMeter.GetComponent<Meter>().setValue(dayTime-currentDayTime);
                orderList = PassengerManager.orderList;
                if (currentDayTime < dayTime) { //if day is running, add logic for delays (earthquake)
                    for (int i = 0; i < PassengerManager.numOrders; i++) {
                        if (orderList.Count > i) {
                            if (orderList[i].GetComponent<Passenger>().getOrderedFood() != "") {
                                orderSheets[i].GetComponent<OrderSheet>().DispSprite(orderList[i].GetComponent<Passenger>().getOrderedFood());
                                orderSheets[i].GetComponent<OrderSheet>().setMeterRefrence(orderList[i]);
                                orderSheets[i].SetActive(true);
                            } else {
                                orderSheets[i].SetActive(false);
                            }
                        } else {
                            orderSheets[i].SetActive(false);
                        }
                    }
                } else { //day ended
                    orderList.Clear();
                    day += 1;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load into transition, later make transition go to after day
                }
            } else { //After-Day
                //  enable/control upgrades
                //  give a way to exit to a normal day
            }
        }
        
        
       
    }
    public void Pause() {
        isPaused = true;
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    public void Unpause() {
        isPaused = false;
        Time.timeScale = 1;
        menu.SetActive(false);
    }
    public void QuitToMenu() {
        SceneManager.LoadScene(0);
    }
    public void Stuck() {
        player.transform.position = new Vector3(0,-15,0);
        Unpause();
    }
}
