using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScore 
{
    public static int ResultScore = 0;

    public static void ScoreSave(int score)
    {
        ResultScore = score;
    }
}
