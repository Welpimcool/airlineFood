using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstorm : MonoBehaviour
{
    private AudioSource babyCry;
    public Background backgroundScript;
    public Color flashColor;
    public Color dimColor;

    private void OnEnable()
    {
        babyCry = transform.GetChild(0).GetComponent<AudioSource>();
        backgroundScript.Dim(1200f, dimColor);
        StartCoroutine(Cycle());
    }

    private void OnDisable()
    {
        babyCry.Stop();
        backgroundScript.Lighten(1400f);
        StopCoroutine(Cycle());
    }

    private IEnumerator Cycle()
    {
        // its okay cuz its in a coroutine
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));
            if (transform.GetComponent<AudioSource>().isPlaying)
            {
                transform.GetComponent<AudioSource>().Stop();
            }

            if (!babyCry.isPlaying)
            {
                babyCry.Play();
            }

            transform.GetComponent<AudioSource>().Play();
            backgroundScript.Flash(.2f, 1400f, flashColor, dimColor);
            transform.GetComponent<ParticleSystem>().Emit(Random.Range(3, 6));
        }
    }


}
