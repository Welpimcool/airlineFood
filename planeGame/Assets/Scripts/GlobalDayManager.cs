using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalDayManager
{
    private static int dayCounter = 1;
    // Start is called before the first frame update
    public static void SetDay(int day)
    {
        dayCounter = day;
    }

    public static int GetDay()
    {
        return dayCounter;
    }
}
