using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransitionLabel : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        print("Day: " + GlobalDayManager.GetDay());
        text.text = "Day " + GlobalDayManager.GetDay() + " complete, " + GlobalScore.GetDayScore() + "pts";
        GlobalScore.SetDayScore(0);
        GlobalDayManager.SetDay(GlobalDayManager.GetDay() + 1);
    }
}
