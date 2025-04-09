using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Passenger : MonoBehaviour
{
    private bool annoyed = false;
    private bool angy = false;
    private bool isOrderActive = false;
    private float timeRemaining;
    private string orderedItem;
    [SerializeField] TextMeshProUGUI orderText;
    Dictionary<string, int> foodList = new() //later change to make a refrence to the ingredient list
    {
        ["Food"] = 0,
        ["Meat Plate"] = 1,
        ["Fish Plate"] = 2
        // [""] = 3,
        // [""] = 4,
        // [""] = 5
    };


    void Start()
    { 
        GetComponentInChildren<Canvas>().enabled = false;
    }
//Gets time remaining in order
    public float getTimeRemaining()
    {
        return timeRemaining;
    }
 //Gets whether the passenger has already ordered
    public bool getIsOrderActive()
    {
        return isOrderActive;
    }
//Processes the actual order
    public IEnumerator Order(float orderTime)
    {
        orderedItem = selectFood();
        Debug.Log(orderedItem);
        bool sensitive = Random.Range(0, 2) == 1;
        float timeRemaining = orderTime;
 //Makes time tick down
        if (annoyed)
        {
            timeRemaining -= orderTime / 5;
        }
        isOrderActive = true;
        yield return new WaitForSeconds(1);
//Prepares Meter
        GetComponentInChildren<Meter>().setMaxValue(orderTime);
        GetComponentInChildren<Canvas>().enabled = true;
        orderText.text = orderedItem;
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            GetComponentInChildren<Meter>().setValue(timeRemaining);
//Makes anger increase if order took too long
            if ((timeRemaining < orderTime / 10 || (sensitive && timeRemaining < orderTime/5 && WeatherShift.weather ==1) && !annoyed))
            {
                if (!angy) 
                {
                    GetComponentInParent<SpriteRenderer>().color = Color.yellow;
                }
                annoyed = true;
            }
//idk why this is needed but it is
            yield return null;
        }
       
        GetComponentInChildren<Canvas>().enabled = false;
        isOrderActive = false;
        GetComponentInParent<PassengerManager>().OrderFailed();
        if (angy)
        {
            GameManager.lose();
        }else
        {
            angy = true;
            annoyed = false;
            GetComponentInParent<SpriteRenderer>().color = Color.red;

        }


    }
    public string selectFood()
    {
        string[] list = new string[3];
        int j = 0;
        foreach (string i in foodList.Keys)
        {
            list[j] = i;
            j++;
        }
        return list[Random.Range(1, 3)];
    }
    public string getOrderedFood()
    {
        return orderedItem;
    }
}
