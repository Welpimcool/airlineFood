using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI score_text;
    // Start is called before the first frame update
    void Start()
    {
        score_text.text = PassengerManager.ordersCompleted.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
