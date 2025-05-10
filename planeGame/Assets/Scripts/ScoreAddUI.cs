using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreAddUI : MonoBehaviour
{
    private Vector3 initialPosition;
    public Vector3 finalPosition;
    public float speed = 1;
    private float lifetime = 0;
    public float maxLifetime = 3;
    private int score = 0;

    public void Initialize(float timeRemaining)
    {
        initialPosition = transform.position;
        score = (int)(GlobalDayManager.GetDay() * timeRemaining * 10);
        GlobalScore.AddToScore(score);
        
        transform.GetChild(0).GetComponent<TMP_Text>().text = "+" + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, initialPosition + finalPosition, Time.deltaTime * speed);

        if (lifetime >= maxLifetime)
        {
            Destroy(transform.gameObject);
        }
    }
}
