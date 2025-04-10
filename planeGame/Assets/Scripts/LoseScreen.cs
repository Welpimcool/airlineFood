using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI timer_text;
    // Start is called before the first frame update
    void Start()
    {
        score_text.text = PassengerManager.ordersCompleted.ToString();
        timer_text.text = timerFormat(PassengerManager.survivalTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private string timerFormat(float time) {
        int minute = (int) time/60;
        int seconds = (int) time % 60;
        return minute+":"+seconds;
    }
}
