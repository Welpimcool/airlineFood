using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GLManager : MonoBehaviour
{
    public Light2D globalLight;
    public Color initialColor;

    private void Start()
    {
        initialColor = globalLight.color;
    }

    public void DisableLight()
    {
        StartCoroutine(DisableLightYES(3000));
    }

    public IEnumerator DisableLightYES(int frames)
    {
        for (float i = 0; i < i / frames; i += 1)
        {
            globalLight.color = Color.Lerp(globalLight.color, initialColor, i);
            yield return new WaitForEndOfFrame();
        }
    }
}
