using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using unityroom.Api;

public class ResultUI : MonoBehaviour
{
    [SerializeField] Text _resultScore;
    [SerializeField] Text _resultSpeedD4;
    [SerializeField] Text _resultSpeedF2;
    [SerializeField] Text _highScore;
    [SerializeField] GameObject _newScoreImage;
    [SerializeField] Text _maxSpeedD4;
    [SerializeField] Text _maxSpeedF2;
    [SerializeField] GameObject _newSpeedImage;

    private void Start()
    {
        _resultScore.text = SaveData.ResultScore.ToString("000000");
        _resultSpeedD4.text = SaveData.ResultSpeed.ToString("0000");
        _resultSpeedF2.text = (SaveData.ResultSpeed % 1).ToString(".00");
        _highScore.text = SaveData.HighScore.ToString("000000");
        _maxSpeedD4.text = SaveData.MaxSpeed.ToString("0000");
        _maxSpeedF2.text = (SaveData.MaxSpeed % 1.0f).ToString(".00");
        if (SaveData.ResultScore == SaveData.HighScore)
            _newScoreImage.SetActive(true);
        else
            _newScoreImage.SetActive(false);
        if (SaveData.ResultSpeed == SaveData.MaxSpeed)
            _newSpeedImage.SetActive(true);
        else
            _newSpeedImage.SetActive(false);

        UnityroomApiClient.Instance.SendScore(0, SaveData.ResultScore, ScoreboardWriteMode.Always);
        UnityroomApiClient.Instance.SendScore(1, SaveData.ResultSpeed, ScoreboardWriteMode.Always);
    }
}
