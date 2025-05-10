using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
// using UnityEditor.PackageManager;
using UnityEngine;

public class WeatherShift : MonoBehaviour
{
    [SerializeField] public GameObject sky;
    [SerializeField] public GameObject rain;
    [SerializeField] public GameObject snow;
    [SerializeField] public GameObject thunder;
    [SerializeField] public GameObject powerOut;
    [SerializeField] public GameObject eventMeter;
    [SerializeField] public MusicManager music;
    [SerializeField] public Dialogue dialogueManager;
    private Vector3 meterPos;
    public static int weather = 0;
    public int eventStatus; //0 is no event, 1 is ongoing, 2 is ended
    public float weatherEndTime;// a varible of at what current day time to end the weather event
    public float weatherDuration = 30f; //weather lasts for 30 seconds
    public static bool thunderstorm;
    public static bool strongWind;
    public Background backgroundScript;
    public Color thunderstormFlashColor;
    public ParticleSystem thunderstormParticles;

    void Start()
    {
        meterPos = eventMeter.transform.localPosition;
        eventMeter.SetActive(false);
        eventStatus = 0;
        weatherDuration += (GlobalDayManager.GetDay()-1) * 5f;
    }

    void Update()
    {
        if (GameManager.currentDayTime > 30 && (eventStatus == 0 || GameManager.isEndless == true))
        {
            eventStatus = 1;
            selectWeatherEvent();
            
            weatherEndTime = GameManager.currentDayTime + weatherDuration;
            eventMeter.SetActive(true);
            eventMeter.GetComponent<Meter>().setMaxValue(weatherDuration);
            music.PlayWeatherMusic();
            
        }
        
        if (eventStatus == 1 && GameManager.currentDayTime > weatherEndTime)
        {
            stopWeatherEvent();
            eventMeter.SetActive(false);
            eventStatus = 2;
            music.PlayNormalMusic();
        }

        if (eventStatus == 1) {
            eventMeter.GetComponent<Meter>().setValue(weatherEndTime - GameManager.currentDayTime);
            float temp = 5f*Mathf.Sin(2*GameManager.currentDayTime);
            eventMeter.transform.localPosition = meterPos + new Vector3(0,temp,0);
        }


        // if (time >= 50) //not needed due to already reseting days
        // {
        //     time = 0;
        //     eventsToday = 0;
        // }
    }

    public void selectWeatherEvent()
    {
        int events = UnityEngine.Random.Range(1, 4);
        if (events == 1)
        {
            weather = 1;
            thunderStorm();
            dialogueManager.QueueMessage("Thunderstorm: Be careful, passengers will get annoyed much more easily", 1f);
        }
        if (events == 2)
        {
            weather = 2;
            blizzard();
            dialogueManager.QueueMessage("Blizzard: It's so cold. Cook time and chop time doubles", 1f);
        }
        if (events == 3)
        {
            weather = 3;
            PowerOut();
            dialogueManager.QueueMessage("Heat Wave: The plane has switched to back up power because of the heat", 1f);
        }
    }

    private void PowerOut()
    {
        powerOut.gameObject.SetActive(true);
    }

    public void stopWeatherEvent() //maybe make stopWeatherEvent stop all weather no matter what like previous clear method, and removes the need or the weather varible
    {
        rain.SetActive(false);
        snow.SetActive(false);
        thunder.SetActive(false);
        powerOut.SetActive(false);
    }

    public void thunderStorm()
    {
        rain.SetActive(true);
        thunder.SetActive(true);
    }

    //blizzard particles done
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
