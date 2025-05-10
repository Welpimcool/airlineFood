using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource normalMusic;
    public AudioSource weatherMusic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWeatherMusic()
    {
        StartCoroutine(PlayTSWeather());
    }

    private IEnumerator PlayTSWeather()
    {
        normalMusic.Stop();
        yield return new WaitForSeconds(.1f);
        weatherMusic.Play();
    }

    public void PlayNormalMusic()
    {
        StartCoroutine(PlayTSNormal());
    }

    private IEnumerator PlayTSNormal()
    {
        weatherMusic.Stop();
        yield return new WaitForSeconds(.1f);
        normalMusic.Play();
    }
}
