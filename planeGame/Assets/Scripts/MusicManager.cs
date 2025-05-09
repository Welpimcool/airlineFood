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
        transform.GetComponent<AudioSource>().Pause();
        transform.GetComponent<AudioSource>().clip = weatherMusic;
        transform.GetComponent<AudioSource>().Play();
    }

    public void PlayNormalMusic()
    {
        transform.GetComponent<AudioSource>().Pause();
        transform.GetComponent<AudioSource>().clip = normalMusic;
        transform.GetComponent<AudioSource>().Play();
    }
}
