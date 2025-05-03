using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderstorm : MonoBehaviour
{
    public Background backgroundScript;
    public Color flashColor;
    public Color dimColor;

    private void OnEnable()
    {
        backgroundScript.Dim(1200f, dimColor);
        StartCoroutine(Cycle());
    }

    private void OnDisable()
    {
        backgroundScript.Lighten(1200f);
        StopCoroutine(Cycle());
    }

    private IEnumerator Cycle()
    {
        // its okay cuz its in a coroutine
        while (true)
        {
            print("flash");
            yield return new WaitForSeconds(Random.Range(5, 8));
            backgroundScript.Flash(.2f, 1400f, flashColor, dimColor);
            transform.GetComponent<ParticleSystem>().Emit(Random.Range(3, 6));
        }
    }


}
