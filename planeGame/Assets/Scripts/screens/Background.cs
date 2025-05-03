using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] public GameObject[] list;
    private float[] pos;
    private float max = -50f;
    private float speed = 2f;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        pos = new float[] {-23.85f,0f,23.85f,47.7f};
        startColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++) {
            pos[i] += -Time.deltaTime*speed;
            if (pos[i] <= max) {
                pos[i] = (23.85f*2)+(pos[i]%23.85f);
            }
            list[i].transform.localPosition = new Vector3(0,pos[i],0);
        }
        // for (int i = 0; i < 4; i++) {
        //     for (int j = 0; j < 4; j++) {
        //         if (!(pos[i]==pos[j])) {
        //             // Debug.Log(i+" is offset from "+j+" by "+(pos[i]-pos[j]));
        //         }
        //     }
        // }
    }

    public void Flash(float lasting, float returnFrames, Color flashColor, Color dimColor)
    {
        StartCoroutine(DoFlash(lasting, returnFrames, flashColor, dimColor));
    }

    private IEnumerator DoFlash(float lasting, float returnFrames, Color flashColor, Color dimColor)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = flashColor;
        }

        yield return new WaitForSeconds(lasting);

        for (float i = 0; i < returnFrames/2; i++)
        {
            yield return new WaitForEndOfFrame();
            for (int o = 0; o < transform.childCount; o++)
            {
                transform.GetChild(o).GetComponent<SpriteRenderer>().color = Color.Lerp(
                    transform.GetChild(o).GetComponent<SpriteRenderer>().color,
                    dimColor, i / returnFrames);
            }
        }


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = dimColor;
        }


        print("done flashing");
    }

    public void Dim(float dimFrames, Color endColor)
    {
        StartCoroutine(DoDim(dimFrames, endColor));
    }

    private IEnumerator DoDim(float dimFrames, Color endColor)
    {
        for (float i = 0; i < dimFrames; i++)
        {
            yield return new WaitForEndOfFrame();
            for (int o = 0; o < transform.childCount; o++)
            {
                transform.GetChild(o).GetComponent<SpriteRenderer>().color = Color.Lerp(
                    transform.GetChild(o).GetComponent<SpriteRenderer>().color,
                    endColor, i / dimFrames);
            }
        }
    }

    public void Lighten(float lightenFrames)
    {
        StartCoroutine(DoLighten(lightenFrames));
    }

    private IEnumerator DoLighten(float lightenFrames)
    {
        for (float i = 0; i < lightenFrames; i++)
        {
            yield return new WaitForEndOfFrame();
            for (int o = 0; o < transform.childCount; o++)
            {
                transform.GetChild(o).GetComponent<SpriteRenderer>().color = Color.Lerp(
                    transform.GetChild(o).GetComponent<SpriteRenderer>().color,
                    startColor, i / lightenFrames);
            }
        }
    }
}
