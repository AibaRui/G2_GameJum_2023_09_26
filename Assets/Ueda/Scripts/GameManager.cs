using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _timeLimit = 60.0f;
    [SerializeField] float _countDownTime = 3.0f;
    [SerializeField] float _speedUpRate = 1.0f;
    bool _isActive = false;
    int _currentScore = 0;
    float _currentTime = 0.0f;
    float _currentSpeed = 0.0f;
    static GameManager instance;

    public static GameManager Instance => instance;
    public int CurrentScore => _currentScore;
    public float CurrentTime => _currentTime;
    public float CurrentSpeed => _currentSpeed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _currentTime = _timeLimit;
        StartCoroutine(CountDown(_countDownTime , () => GameStart()));
    }
    IEnumerator CountDown(float time ,Action callback)
    {
        float timer = time;
        string text = "";
        //_timeText.color = Color.red;
        //_scoreText.gameObject.transform.parent.gameObject.SetActive(true);
        //_timeText.gameObject.transform.parent.gameObject.SetActive(true);
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            if(text != timer.ToString("0") && text != "Start !!")
            {
                text = timer.ToString("0");
                if(text == "0")
                {
                    text = "Start !!";
                }
                print(text);
            }
            yield return null;
        }
        callback();
        //_timeText.text = " Start !! ";
        //_startEvent?.Invoke();
        //_nowGame = StartCoroutine(GameTimer());
    }
    void GameStart()
    {
        _isActive = true;
    }
    void Update()
    {
        if(_isActive)
        {
            _currentTime -= Time.deltaTime;
            _currentSpeed += Time.deltaTime * _speedUpRate;
            print($"CurrentSpeed :{CurrentSpeed}");
            print($"CurrentScore :{CurrentScore}");
            print($"CurrentTime :{CurrentTime}"); 
            if ( _currentTime < 0.0f )
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        _isActive = false;
    }
    public void AddScore(int score)
    {
        _currentScore += score ;
        if(_currentScore < 0 )
        {
            _currentScore = 0;
        }
    }
}
