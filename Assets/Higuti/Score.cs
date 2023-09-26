using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    private int _drawValue = 0;
    public int DrawValue => _drawValue;

    private void Start()
    {
        _scoreText = GetComponent<Text>();

        Play(0, 200, 1);
    }

    public void ApplyText()
    {
        _scoreText.text = _drawValue.ToString();
    }

    public void Play(int initialValue, int endValue, float duration)
    {
        Debug.Log("DD");
        _drawValue = initialValue;
        DOTween.To(
            () => _drawValue,
            value => _drawValue = value,
            endValue,
            duration).OnUpdate(() => _scoreText.text = _drawValue.ToString());
    }
}

