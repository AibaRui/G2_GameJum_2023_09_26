using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : SingletonBase<AudioManager>
{
    //SE�̊��蓖��
    public enum SEType
    {
        Acceleration = 0,    //����
        Deceleration = 1,    //����
        Clash = 2,        //�Փ�
        Destruction = 3,    //�j��
        BoostPanel = 4,        //�u�[�X�g�p�l��
        FlyAway = 5,        //�ᑬ���G���W����
        HighEngine = 6,        //�������G���W����
        Idle = 7,        //�G���W���A�C�h����
        Start = 8,        //rece �J�n��
        Goal = 9,        //Goal��
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
    //BGM�̊��蓖��
    public enum BGMType
    {
        Title = 0,        //�^�C�g����ʂ�
        LowSpeedBGM = 1,    //�X�s�[�h���x���Ƃ���BGM
        HighSpeedBGM = 2,    //�X�s�[�h�������Ƃ���BGM
        Result = 3,        //���U���g��ʂ�
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
    /// �����Ń{�����[����ς��Ă�������
    /// </summary>
    /// <param name="value"></param>
    public void ChangeSEVolumeByRate(float value)
    {
        _audioSESource.volume *= value;
    }
    /// <summary>
    /// �����Ń{�����[����ς��Ă�������
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
