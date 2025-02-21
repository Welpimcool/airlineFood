using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    private float anger;
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
        isOrderActive = true;
        yield return new WaitForSeconds(1);
        //Prepares Meter
        GetComponentInChildren<Meter>().setMaxValue(orderTime);
        GetComponentInChildren<Canvas>().enabled = true;

        float timeRemaining = orderTime;
        //Makes time tick down
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            GetComponentInChildren<Meter>().setValue(timeRemaining);
            //Makes anger increase if order took too long
            if (timeRemaining < orderTime / 4)
            {
                anger += Time.deltaTime;
            }
            yield return null;
            if (anger >= 5)
            {
                GetComponentInParent<SpriteRenderer>().color = Color.red;
            }

        }
    }
}
