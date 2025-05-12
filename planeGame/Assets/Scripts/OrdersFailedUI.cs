using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OrdersFailedUI : MonoBehaviour
{
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = PassengerManager.ordersFailed + "/"+Difficulty.diff+" failed";
    }
}
