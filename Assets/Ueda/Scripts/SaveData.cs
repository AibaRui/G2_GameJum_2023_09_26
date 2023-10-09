using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveData 
{
    public static int ResultScore = 0;
    public static float ResultSpeed = 0;
    public static float HighScore = 0;
    public static float MaxSpeed = 0;
    public static void ScoreSave(int score)
    {
        ResultScore = score; 
        HighScore = HighScore < ResultScore ? ResultScore : HighScore;
    }
    public static void SpeedSave(float speed)
    {
        ResultSpeed = speed;
        MaxSpeed = MaxSpeed < ResultSpeed ? ResultSpeed : MaxSpeed;
    }

}
