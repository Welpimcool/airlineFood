using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalScore
{
    private static int score;
    private static int dayScore;

    // Set total score
    public static void SetScore(int value)
    {
        score = value;
    }

    // Get total score
    public static int GetScore()
    {
        return score;
    }

    // Set day score
    public static void SetDayScore(int value)
    {
        dayScore = value;
    }

    // Get day score
    public static int GetDayScore()
    {
        return dayScore;
    }

    // Optional: Add to day score
    public static void AddToScore(int amount)
    {
        dayScore += amount;
        score += amount;
    }

}
