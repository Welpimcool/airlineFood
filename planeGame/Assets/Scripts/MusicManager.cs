using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource normalMusic;
    public AudioSource weatherMusic;
    public bool audioOn;

    void Start()
    {
        audioOn = true;
    }
    public void AudioOff()
    {
        audioOn = false;
        normalMusic.Stop();
        weatherMusic.Stop();
    }
    public void AudioBackOn()
    {
        audioOn = true;
        normalMusic.Play();
    }
    public void PlayWeatherMusic()
    {
        if (audioOn)
        {
            StartCoroutine(PlayTSWeather());
        }
    }

    private IEnumerator PlayTSWeather()
    {
        normalMusic.Stop();
        yield return new WaitForSeconds(.1f);
        weatherMusic.Play();
    }

    public void PlayNormalMusic()
    {
        if (audioOn)
        {
            StartCoroutine(PlayTSNormal());
        }
    }


    private IEnumerator PlayTSNormal()
    {
        weatherMusic.Stop();
        yield return new WaitForSeconds(.1f);
        normalMusic.Play();
    }
}
