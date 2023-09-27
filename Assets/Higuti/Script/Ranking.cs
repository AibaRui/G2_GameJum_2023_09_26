using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    [SerializeField]bool Delete = false;
    UI _ui = new UI();
    GameManager _gm = new GameManager();
    string[] rank = { "1ˆÊ", "2ˆÊ", "3ˆÊ", "4ˆÊ", "5ˆÊ" };
    int[] rankingValue = new int[5];
    [SerializeField]Text[] rankingText = new Text[5];
    void Awake()
    {
        int currentScore = SaveScore.ResultScore;
        Getranking();
        Setranking(currentScore);
        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString("f2");
        }
        if(Delete) PlayerPrefs.DeleteAll();
    }
    void Getranking()
    {
        for (int i = 0; i < rank.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt(rank[i]);
        }
    }

    void Setranking(int value)
    {
        for (int i = 0; i < rank.Length; i++)
        {
            if (value > rankingValue[i])
            {
                var change = rankingValue[i];
                rankingValue[i] = value;
                value = change;
            }
        }
        for (int i = 0; i < rank.Length; i++)
        {
            PlayerPrefs.SetInt(rank[i], rankingValue[i]);
        }
    }
}
