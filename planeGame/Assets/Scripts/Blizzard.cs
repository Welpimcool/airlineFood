using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blizzard : MonoBehaviour
{
    private void OnEnable()
    {
        Stove.speed = .75f;
        CuttingBoard.setSpeed(0.5f);
    }

    private void OnDisable()
    {
        Stove.speed = 1.5f;
        CuttingBoard.setSpeed(1f);
    }
}
