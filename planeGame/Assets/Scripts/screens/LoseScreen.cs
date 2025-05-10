using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{

    [SerializeField] TMP_Text score_text;
    [SerializeField] TMP_Text timer_text;
    // Start is called before the first frame update
    void Start()
    {
        score_text.text = "Score: " + GlobalScore.GetScore() + "pts";
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

    public void callMenu()
    {
        SceneManager.LoadScene(0);
    }
}
