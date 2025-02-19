using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    private float anger;
    private float orderTime;
    private bool isOrderActive;
    private float timeRemaining;

    void Start()
    {
        orderTime = 60;
        StartCoroutine(Order(orderTime));
        GetComponentInChildren<Meter>().setMaxValue(orderTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public float getTimeRemaining()
    {
        return timeRemaining;
    }
    private IEnumerator Order(float orderTime)
    {
        float timeRemaining = orderTime;
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            GetComponentInChildren<Meter>().setValue(timeRemaining);
            if (timeRemaining < orderTime / 4)
            {
                anger += Time.deltaTime;
            }
            yield return null;
            // Debug.Log(timeRemaining);
            // Debug.Log(anger);
            if (anger >= 5)
            {
                GetComponentInParent<SpriteRenderer>().color = Color.red;
            }

        }
    }
}
