using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public enum Gear
    {
        Gear0,
        Gear1,
        Gear2,
        Gear3,
        Gear4,
    }
    [SerializeField] Text CountDownText;
    [SerializeField] float _timeLimit = 60.0f;
    [SerializeField] float _countDownTime = 3.0f;
    [SerializeField] float _speedUpRate = 1.0f;
    bool _isActive = false;
    int _currentScore = 0;
    float _currentTime = 0.0f;
    float _currentSpeed = 0.0f;
    static GameManager instance;
    Gear _nowGear = Gear.Gear0;
    public static GameManager Instance => instance;
    public int CurrentScore => _currentScore;
    public float CurrentTime => _currentTime;
    public float CurrentSpeed => _currentSpeed;
    public Gear NowGear => _nowGear;
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
            //print($"CurrentScore :{CurrentScore}");
            //print($"CurrentTime :{CurrentTime}");
            GearObserve(_currentSpeed);
            if ( _currentTime < 0.0f )
            {
                GameOver();
            }
        }
    }
    void GearObserve(float speed)
    {
        if(speed < 30.0f)
        {
            GearUpdate(Gear.Gear0);
        }
        else if(speed < 100.0f)
        {
            GearUpdate(Gear.Gear1);
        }
        else if(speed < 400.0f)
        {
            GearUpdate(Gear.Gear2);
        }
        else if(speed < 700.0f)
        {
            GearUpdate(Gear.Gear3);
        }
        else if(700.0f < speed)
        { 
            GearUpdate(Gear.Gear4);
        }
    }
    void GearUpdate(Gear gear)
    {
        if(_nowGear != gear)
        {
            _nowGear = gear;
            print(_nowGear);
        }
    }
    void GameOver()
    {
        _isActive = false;
        SceneController.Instance?.FadeAndNextScene("result");
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
