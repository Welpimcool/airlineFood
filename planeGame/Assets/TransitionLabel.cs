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
        text.text = "Day " + GlobalDayManager.GetDay() + " complete";
        GlobalDayManager.SetDay(GlobalDayManager.GetDay() + 1);
    }
}
