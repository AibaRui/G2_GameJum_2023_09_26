using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NewBehaviourScript : MonoBehaviour
{
    UI _ui = new UI();
    GameManager _gm = new GameManager();
    List<int> ranking;
    int score_num;
     
    void Start()
    {
        score_num = PlayerPrefs.GetInt("SCORE", 0); 
        
    }

    // Update is called once per frame
    void  Update()
    {
        
    }

    //public void Save(int Score)
    //{
    //    score_num = PlayerPrefs.SetInt("SCOER", Score, score_num);
    //}
}
