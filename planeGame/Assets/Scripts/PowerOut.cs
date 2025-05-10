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
    public Vector3 finalScale;
    private Vector3 initialScale;

    private void Start()
    {
        // initialColor = globalLight.color;
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    private void OnEnable()
    {
        lightRays.gameObject.SetActive(true);
        StartCoroutine(EnableLight(3000));
    }

    private IEnumerator EnableLight(int frames)
    {
        for (float i = 0; i <= 1; i += 1.0f/frames)
        {
            globalLight.color = Color.Lerp(globalLight.color, lightColor, i);
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, i);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDisable()
    {
        glManager.DisableLight();
        lightRays.gameObject.SetActive(false);
    }

    
}
