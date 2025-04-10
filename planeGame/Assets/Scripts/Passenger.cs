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

    public float getTimeRemaining() //Gets time remaining in order
    {
        return timeRemaining;
    }
 
    public bool getIsOrderActive() //Gets whether the passenger has already ordered
    {
        return isOrderActive;
    }
    
    public IEnumerator Order(float orderTime) //Processes the actual order
    {
        orderedItem = selectFood();
        // Debug.Log(orderedItem);
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
        while (isOrderActive &&timeRemaining > 0)
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
                annoyed = true; //maybe make it so they cannot be annoyed and angry?
            }
            //idk why this is needed but it is
            yield return null;
        }
       
        GetComponentInChildren<Canvas>().enabled = false;
        if(isOrderActive == false)
        {
            Debug.Log("Order Stopped");
        }
        else
        {
            Debug.Log("Order Failed");
            GetComponentInParent<PassengerManager>().OrderFailed();
            if (angy)
            {
                GameManager.lose();
            }
            else
            {
                angy = true;
                annoyed = false;
                GetComponentInParent<SpriteRenderer>().color = Color.red;
                isOrderActive = false;

            }
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

    public bool onInteraction(GameObject item) { 
        /*
        current idea:
        interaction with player, needs to detect if the passanger has an order
        compare players item with the order, and if order is filled then destroy player item
        (use bool to determine destroyed or not) 


        alternitive idea:
        make the passenger hold the food even if it is incorrect 
        and have main order loop check if the holding item is correct 
        instead of having to make this function stop the main one
        */
        
        if (isOrderActive) {
            if (item.GetComponentInChildren<Ingredient>().getName().Equals(orderedItem)) { // THERE IS AN ERROR, order is correctly filled but not fully stopped
                //mark order as complete

                isOrderActive = false;
                GetComponentInParent<PassengerManager>().OrderComplete(); //i dont know what other varibles need to be changed
                //IEnumerator functions might break if things change half way through


                Debug.Log("order filled");
                return true; //tells player to delete item
            }
            Debug.Log("Incorrect item, needed:"+orderedItem+", gave:"+item.GetComponentInChildren<Ingredient>().getName());
        } else {
            Debug.Log("The passenger is not ordering");
        }
        return false;
    }

    public string getOrderedFood()
    {
        return orderedItem;
    }
}
