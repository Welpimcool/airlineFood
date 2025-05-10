using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayUI : MonoBehaviour
{
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<TMP_Text>();
        text.text = "Day " + GlobalDayManager.GetDay();
    }
}
