using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PowerOut : MonoBehaviour
{
    public Light2D globalLight;
    public Transform lightRays;
    public Color lightColor;
    public Color initialColor;
    public GLManager glManager;

    private void Start()
    {
        // initialColor = globalLight.color;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        lightRays.gameObject.SetActive(true);
        StartCoroutine(EnableLight(1000));
    }

    private IEnumerator EnableLight(int frames)
    {
        for (float i = 0; i < i/frames; i += 1)
        {
            globalLight.color = Color.Lerp(globalLight.color, lightColor, i);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDisable()
    {
        glManager.DisableLight();
        lightRays.gameObject.SetActive(false);
    }

    
}
