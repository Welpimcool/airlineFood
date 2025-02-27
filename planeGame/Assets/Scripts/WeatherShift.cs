using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherShift : MonoBehaviour
{
    [SerializeField]public GameObject sky;
    [SerializeField] public GameObject rain;
    [SerializeField] public GameObject snow;
    [SerializeField] public GameObject powerOut;
    public static int weather = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            powerOut.SetActive(false);
            weather = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
           
            powerOut.SetActive(false);
            weather = 0;
            snow.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            powerOut.SetActive(true);
            weather = 2;
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            snow.SetActive(true);
            weather = 3;

        }
        if (weather == 1)
        {
            sky.SetActive(true);
            rain.SetActive(true);
        }
        else
        {
            sky.SetActive(false);
            rain.SetActive(false);
        }
    }
}
