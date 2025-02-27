using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    private bool angy = false;
    private bool isOrderActive = false;
    private float timeRemaining;

   

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
        bool sensitive = Random.Range(0, 2) == 1;
        float timeRemaining = orderTime;
 //Makes time tick down
        if (angy)
        {
            timeRemaining -= orderTime / 5;
        }
        isOrderActive = true;
        yield return new WaitForSeconds(1);
//Prepares Meter
        GetComponentInChildren<Meter>().setMaxValue(orderTime);
        GetComponentInChildren<Canvas>().enabled = true;
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            GetComponentInChildren<Meter>().setValue(timeRemaining);
//Makes anger increase if order took too long
            if (timeRemaining < orderTime / 10 || (sensitive && timeRemaining < orderTime/5 && WeatherShift.weather ==1))
            {
                angy = true;
                GetComponentInParent<SpriteRenderer>().color = Color.red;
            }
//idk why this is needed but it is
            yield return null;
        }
        GetComponentInChildren<Canvas>().enabled = false;
        isOrderActive = false;
        GetComponentInParent<PassengerManager>().OrderFailed();
    }
}
