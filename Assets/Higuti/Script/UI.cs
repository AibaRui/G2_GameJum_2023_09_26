using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UI : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    [SerializeField] Text speedText;
    [SerializeField] Text millspeedText;
    [SerializeField] Slider Speedslider;
    private int _drawValue = 0;

    public void slider(float slide)
    {
        Speedslider.value = slide;
    }
    public void SliderValue(float Min , float Max)
    {
        Speedslider.minValue = Min;
        Speedslider.maxValue = Max;
    }
    public void TimeText(float timer)
    {
        timerText.text = timer.ToString("00.00");
    }

    public void ScoreText(int score)
    {
        scoreText.text = score.ToString("0000");
    }
    public void SpeedText(float speed)
    {
        speedText.text = speed.ToString("0").Replace("1"," 1");
        millspeedText.text = (speed % 1).ToString(".00").Replace("1", " 1");
    }

    public int DrawValue => _drawValue;
    public void Play(int initialValue, int endValue, float duration)
    {
        _drawValue = initialValue;
        DOTween.To(
            () => _drawValue,
            value => _drawValue = value,
            endValue,
            duration).OnUpdate(() => scoreText.text = _drawValue.ToString());
    }
}
