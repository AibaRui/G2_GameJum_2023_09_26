using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using static GameManager;

public class GameManager : MonoBehaviour
{
    public enum Gear
    {
        Gear0,
        Gear1,
        Gear2,
        Gear3,
        Gear4,
        Gear5,
    }
    [SerializeField] UI _UIcomp;
    [SerializeField] float _UIduration = 0.2f;
    [SerializeField] Text _countDownText;
    [SerializeField] float _timeLimit = 60.0f;
    [SerializeField] float _countDownTime = 3.0f;
    [SerializeField] float _speedUpRate = 1.0f;
    [SerializeField] float _gearChangeRate = 0.95f;
    [SerializeField] float[] _gearCollection ;
    public static Dictionary<Gear, float> GearSpeed = new () {
        {Gear.Gear0 ,30.0f} ,{Gear.Gear1 ,100.0f} ,{Gear.Gear2 ,400.0f} ,{Gear.Gear3 ,700.0f} ,{Gear.Gear4 ,1200.0f}, {Gear.Gear5 ,3000.0f}};
    bool _isActive = false;
    int _currentScore = 0;
    float _currentTime = 0.0f;
    float _currentSpeed = 5.0f;
    static GameManager instance;
    Gear _nowGear = Gear.Gear0;
    public static GameManager Instance => instance;
    public int CurrentScore => _currentScore;
    public float CurrentTime => _currentTime;
    public float CurrentSpeed => _currentSpeed;
    public Gear NowGear => _nowGear;
    public UnityEvent StartEvent;
    public UnityEvent EndEvent;
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
        _countDownText.gameObject.SetActive(true);
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            if(text != timer.ToString("0") && text != "Start !")
            {
                text = timer.ToString("0");
                if (text == "0")
                    text = "Start !";
                _countDownText.text = text;
                _countDownText.transform.DOScale(2f, 0.3f).OnComplete(() => _countDownText.transform.DOScale(1f, 0.3f));
            }
            yield return null;
        }
        _countDownText.gameObject.SetActive(false);
        callback();
    }
    void GameStart()
    {
        _isActive = true;
        StartEvent?.Invoke();
        GearChange(_nowGear);
    }
    void Update()
    {
        if(_isActive)
        {
            _currentTime -= Time.deltaTime;
            //_currentSpeed += Time.deltaTime * _speedUpRate;
            _currentSpeed += ((GearSpeed[_nowGear] - _currentSpeed) / _gearCollection[(int)_nowGear]) * _speedUpRate * Time.deltaTime ;
            //print($"CurrentSpeed :{CurrentSpeed}");
            //print($"_gearCollection :{_gearCollection[(int)_nowGear]}");
            //print($"CurrentTime :{CurrentTime}");
            GearObserve(_currentSpeed);
            _UIcomp.TimeText(_currentTime);
            _UIcomp.slider(_currentSpeed);
            _UIcomp.SpeedText(_currentSpeed);
            if ( _currentTime < 0.0f )
            {
                GameOver();
            }
        }
    }

    void GearObserve(float speed)
    {
        if(speed < GearSpeed[Gear.Gear0] * _gearChangeRate)
        {
            GearUpdate(Gear.Gear0);
        }
        else if(speed < GearSpeed[Gear.Gear1] * _gearChangeRate)
        {
            GearUpdate(Gear.Gear1);
        }
        else if(speed < GearSpeed[Gear.Gear2] * _gearChangeRate)
        {
            GearUpdate(Gear.Gear2);
        }
        else if(speed < GearSpeed[Gear.Gear3] * _gearChangeRate)
        {
            GearUpdate(Gear.Gear3);
        }
        else if (speed < GearSpeed[Gear.Gear4] * _gearChangeRate)
        {
            GearUpdate(Gear.Gear4);
        }
        else if(GearSpeed[Gear.Gear4] * _gearChangeRate < speed)
        { 
            GearUpdate(Gear.Gear5);
        }
    }
    void GearUpdate(Gear gear)
    {
        if(_nowGear != gear)
        {
            GearChange(gear);
        }
    }
    void GearChange(Gear gear)
    {
        if(gear == Gear.Gear0)
        {
            _UIcomp.SliderValue(0, GearSpeed[gear]);
        }
        else
        {
            _UIcomp.SliderValue(GearSpeed[_nowGear], GearSpeed[gear]);
        }
       
        _nowGear = gear;
        print((int)_nowGear);
        _UIcomp.gameObject.GetComponentInChildren<SpeedUISwicher>().ChangeSprite((int)_nowGear);
       
    }
    void GameOver()
    {
        _isActive = false;
        EndEvent?.Invoke();
    }
    public void ToResultScene()
    {
        SceneController.Instance?.FadeAndNextScene("result");
    }
    public void AddScore(int score)
    {
        _UIcomp.Play(_currentScore , (_currentScore + score > 0) ? _currentScore + score : 0 , _UIduration);
        _currentScore += score ;
        if(_currentScore < 0 )
        {
            _currentScore = 0;
        }
    }
    public void AddSpeed(float speed)
    {
        _currentSpeed += speed ;
        if(_currentSpeed < 0 )
        {
            _currentSpeed= 0;
        }
    }
    //IEnumerator CountDown(float time, Action callback)
    //{
    //    float timer = time;
    //    int iTime = -1;
    //    //_timeText.color = Color.red;
    //    //_scoreText.gameObject.transform.parent.gameObject.SetActive(true);
    //    //_timeText.gameObject.transform.parent.gameObject.SetActive(true);
    //    _countDownImage.gameObject.SetActive(true);
    //    while (timer > 0f)
    //    {
    //        timer -= Time.deltaTime;
    //        if (iTime != (int)(timer + 0.5f))
    //        {
    //            iTime = (int)(timer + 0.5f);
    //            _countDownImage.sprite = _countDownSprite[iTime];
    //            _countDownImage.SetNativeSize();
    //            _countDownImage.transform.DOScale(2f, 0.3f).OnComplete(() => _countDownImage.transform.DOScale(1f, 0.3f));
    //        }
    //        yield return null;
    //    }
    //    _countDownImage.gameObject.SetActive(false);
    //    callback();
    //    //_startEvent?.Invoke();
    //    //_nowGame = StartCoroutine(GameTimer());
    //}
}
