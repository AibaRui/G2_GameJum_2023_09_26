using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    protected void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
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
    Gear _nowGear = Gear.Gear0;
    public int CurrentScore => _currentScore;
    public float CurrentTime => _currentTime;
    public float CurrentSpeed => _currentSpeed;
    public Gear NowGear => _nowGear;
    public UnityEvent StartEvent;
    public UnityEvent EndEvent;
    public UnityEvent<Gear> GearChangeEvent;
    void Start()
    {
        _currentTime = _timeLimit;
        StartCoroutine(CountDown(_countDownTime , () => GameStart()));
        AudioManager.Instance.PlayBGM(AudioManager.BGMType.LowSpeedBGM);
       // AudioManager.Instance.PlaySE(AudioManager.SEType.LowEngine);
       AudioManager.Instance.PlaySE(AudioManager.SEType.Start);
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
            _currentSpeed += ((GearSpeed[_nowGear] - _currentSpeed) / _gearCollection[(int)_nowGear]) * _speedUpRate * Time.deltaTime ;
            GearObserve(_currentSpeed);
            _UIcomp.TimeText(_currentTime > 0 ? _currentTime : 0);
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
        if (NowGear != Gear.Gear5 && GearSpeed[NowGear] * _gearChangeRate < speed)
        {
            GearUpdate(NowGear + 1);
        }
        else if (NowGear != Gear.Gear0 && speed < GearSpeed[NowGear - 1] * _gearChangeRate )
        {
            GearUpdate(NowGear - 1);
        }
    }
    void GearUpdate(Gear gear)
    {
        if(_nowGear != gear)
        {
            if(gear == Gear.Gear4)
            {
                AudioManager.Instance.PlayBGM(AudioManager.BGMType.HighSpeedBGM);
                AudioManager.Instance.ChangeSEVolumeByRate(0.7f);
                EndEvent.AddListener(AudioManager.Instance.SEVolumeToDefault);
            }
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
            AudioManager.Instance.PlaySE(AudioManager.EngineSEType.GearChange);
            AudioManager.Instance.PlaySE((AudioManager.EngineSEType)gear + (int)AudioManager.EngineSEType.GearChange);
            _UIcomp.SliderValue(GearSpeed[_nowGear], GearSpeed[gear]);

        }
        GearChangeEvent?.Invoke(gear);
        _nowGear = gear;
        _UIcomp.gameObject.GetComponentInChildren<SpeedUISwicher>().ChangeSprite((int)_nowGear);
    }
    void GameOver()
    {
        _isActive = false;
        EndEvent?.Invoke();
        AudioManager.Instance.PlaySE(AudioManager.SEType.Goal);
        SaveData.ScoreSave(CurrentScore);
        SaveData.SpeedSave(CurrentSpeed);

    }
    public void ToResultScene()
    {
        SceneController.Instance?.FadeAndNextScene("result");
    }
    public void AddScore(int score)
    {
        if (_isActive)
        {
            _UIcomp.Play(_currentScore, (_currentScore + score > 0) ? _currentScore + score : 0, _UIduration);
            _currentScore += score;
            if (_currentScore < 0)
            {
                _currentScore = 0;
            }
        }

    }
    public void AddSpeed(float speed)
    {
        if (_isActive)
        {
            _currentSpeed += speed;
            if (_currentSpeed < 0)
            {
                _currentSpeed = 0;
            }
        }

    }
}
