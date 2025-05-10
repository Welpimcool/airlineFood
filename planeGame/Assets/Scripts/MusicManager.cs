using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip normalMusic;
    public AudioClip weatherMusic;

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
        yield return new WaitForSeconds(.1f);
        transform.GetComponent<AudioSource>().Stop();
        transform.GetComponent<AudioSource>().clip = weatherMusic;
        transform.GetComponent<AudioSource>().Play();
    }

    public void PlayNormalMusic()
    {
        StartCoroutine(PlayTSNormal());
    }

    private IEnumerator PlayTSNormal()
    {
        yield return new WaitForSeconds(.1f);
        transform.GetComponent<AudioSource>().Stop();
        transform.GetComponent<AudioSource>().clip = normalMusic;
        transform.GetComponent<AudioSource>().Play();
    }
}
