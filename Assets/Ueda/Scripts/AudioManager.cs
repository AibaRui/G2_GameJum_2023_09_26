using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    //SEの割り当て
    public enum SEType
    {
        Acceleration = 0,    //加速
        Deceleration = 1,    //減速
        Clash = 2,        //衝突
        Destruction = 3,    //破壊
        BoostPanel = 4,        //ブーストパネル
        LowEngine = 5,        //低速時エンジン音
        HighEngine = 6,        //高速時エンジン音
        Idle = 7,        //エンジンアイドル時
        Start = 8,        //rece 開始時
        Goal = 9,        //Goal時
    }
    //BGMの割り当て
    public enum BGMType
    {
        Title = 0,        //タイトル画面で
        LowSpeedBGM = 1,    //スピードが遅いときのBGM
        HighSpeedBGM = 2,    //スピードが速いときのBGM
        Result = 3,        //リザルト画面で
    }
    public AudioSource _audioSESource;
    public AudioSource _audioBGMSource;
    [SerializeField]  AudioClip[] _audioSEClips;
    [SerializeField]  AudioClip[] _audioBGMClips;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void PlaySE(SEType soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[(int)soundIndex]);
    public void PlaySE(int soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[soundIndex]);
    public void PlayBGM(BGMType soundIndex)
    {
        _audioBGMSource.clip = _audioBGMClips[(int)soundIndex];
        _audioBGMSource.Play();
    }

}
