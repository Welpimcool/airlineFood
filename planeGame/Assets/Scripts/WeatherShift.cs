using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherShift : MonoBehaviour
{
    [SerializeField]public GameObject sky;
    [SerializeField] public GameObject rain;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            sky.SetActive(true);
            rain.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            sky.SetActive(false);
            rain.SetActive(false);
        }
    }
}
