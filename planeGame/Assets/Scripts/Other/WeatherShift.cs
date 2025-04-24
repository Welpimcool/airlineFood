using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class WeatherShift : MonoBehaviour
{
    [SerializeField] public GameObject sky;
    [SerializeField] public GameObject rain;
    [SerializeField] public GameObject snow;
    [SerializeField] public GameObject powerOut;
    public static int weather = 0;
    public float time;
    public int eventsToday;
    public static bool thunderstorm;
    public static bool strongWind;

    public void Start()
    {
 
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time > 60 && (eventsToday < 1||GameManager.isEndless == true))
        {
            
        }
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
    public void selectWeatherEvent()
    {
        int events = UnityEngine.Random.Range(1, 7);
        if (events == 1)
        {
            
        }
        if (events == 2)
        {

        }
        if (events == 3)
        {

        }
        if (events == 4)
        {

        }
        if (events == 5)
        {

        }
        if (events == 6)
        {

        }
    }
    public void thunderStorm()
    {
        sky.SetActive(true);
        rain.SetActive(true);
    }
    public void blizzard()
    {
        snow.SetActive(true);
    }
    public void heatWave()
    {
        powerOut.SetActive(true);
    }
    public void fearMagneto()
    {
        heatWave();
        blizzard();
    }
    public void hurricane()
    {
        thunderStorm();
        blizzard();
        snow.SetActive(false);
    }
    public void earthquake()
    {

    }
    public void clear()
    {
        sky.SetActive(false);
        rain.SetActive(false);
        snow.SetActive(false);
        powerOut.SetActive(false);
    }
}
