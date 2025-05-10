using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public float lerpSpeed = 5f;
    private TMP_Text text;
    private int value = 0;

    private void Start()
    {
        text = transform.GetComponent<TMP_Text>();
    }

    // Update is calvled once per frame
    void Update()
    {
        value = (int)Mathf.Lerp(value, GlobalScore.GetScore(), lerpSpeed * Time.deltaTime);
        text.text = value + "pts";
    }
}
