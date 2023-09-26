using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UI : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] Text timerText;
    [SerializeField] Text speedText;
    [SerializeField] Slider Speedslider;
    private int _drawValue = 0;

    public void slider(float slide)
    {
        Speedslider.value = slide;
    }
    public void TimeText(float timer)
    {
        timerText.text = timer.ToString("f2");
    }

    public void ScoreText(int score)
    {
        scoreText.text = score.ToString("f2");
    }
    public void SpeedText(float speed)
    {
        speedText.text = speed.ToString("f2");
    }

    public int DrawValue => _drawValue;
    public void Play(int initialValue, int endValue, float duration)
    {
        Debug.Log("DD");
        _drawValue = initialValue;
        DOTween.To(
            () => _drawValue,
            value => _drawValue = value,
            endValue,
            duration).OnUpdate(() => scoreText.text = _drawValue.ToString());
    }
}
