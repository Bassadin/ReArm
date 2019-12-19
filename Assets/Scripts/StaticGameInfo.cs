using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticGameInfo
{
    private static int lastGameScore = 0;

    public static void setLastGameScore(int score) {
        lastGameScore = score;
    }

    public static int getLastGameScore()
    {
        return lastGameScore;
    }
}
