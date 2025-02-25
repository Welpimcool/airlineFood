using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherShift : MonoBehaviour
{
    [SerializeField]public GameObject sky;
    [SerializeField] public GameObject rain;
    public static int weather = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sky.SetActive(true);
            rain.SetActive(true);
            weather = 1;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            sky.SetActive(false);
            rain.SetActive(false);
            weather = 0;
        }
    }
}
