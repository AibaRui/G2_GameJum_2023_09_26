using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    //SEの割り当て
    public enum SEType
    {
        Acceleration = 0,    //加速
        Deceleration = 1,    //減速
        Clash = 2,        //衝突
        Destruction = 3,    //破壊
        BoostPanel = 4,        //ブーストパネル
        FlyAway = 5,        //低速時エンジン音
        HighEngine = 6,        //高速時エンジン音
        Idle = 7,        //エンジンアイドル時
        Start = 8,        //rece 開始時
        Goal = 9,        //Goal時
    }
    public enum EngineSEType
    {
        GearChange = 10,
        Gear0 = 11,
        Gear1 = 12,
        Gear2 = 13,
        Gear3 = 14,
        Gear4 = 15,
        Gear5 = 16,
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
    [SerializeField] AudioClip[] _audioSEClips;
    [SerializeField] AudioClip[] _audioBGMClips;
    float _defaultSEVolume;
    float _defaultBGMVolume;
    protected override void AwakeFunction() 
    {
        _defaultSEVolume = _audioSESource.volume;
        _defaultBGMVolume = _audioBGMSource.volume;
    }
    public void PlaySE(SEType soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[(int)soundIndex]);
    public void PlaySE(EngineSEType soundIndex)
    => _audioSESource.PlayOneShot(_audioSEClips[(int)soundIndex]);
    public void PlaySE(int soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[soundIndex]);
    public void PlayBGM(BGMType soundIndex)
    {
        _audioBGMSource.clip = _audioBGMClips[(int)soundIndex];
        _audioBGMSource.Play();
    }
    /// <summary>
    /// 割合でボリュームを変えてください
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSEVolumeByRate(float value)
    {
        _audioSESource.volume *= value;
    }
    /// <summary>
    /// 割合でボリュームを変えてください
    /// </summary>
    /// <param name="value"></param>
    public void ChangeBGMVolumeByRate(float value)
    {
        _audioBGMSource.volume *= value;
    }
    public void SEVolumeToDefault()
    {
        _audioSESource.volume = _defaultSEVolume;
    }
    public void BGMVolumeToDefault()
    {
        _audioBGMSource.volume = _defaultBGMVolume;
    }

}
