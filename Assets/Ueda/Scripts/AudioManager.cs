using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    //SE�̊��蓖��
    public enum SEType
    {
        Acceleration = 0,    //����
        Deceleration = 1,    //����
        Clash = 2,        //�Փ�
        Destruction = 3,    //�j��
        BoostPanel = 4,        //�u�[�X�g�p�l��
        LowEngine = 5,        //�ᑬ���G���W����
        HighEngine = 6,        //�������G���W����
        Idle = 7,        //�G���W���A�C�h����
        Start = 8,        //rece �J�n��
        Goal = 9,        //Goal��
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
