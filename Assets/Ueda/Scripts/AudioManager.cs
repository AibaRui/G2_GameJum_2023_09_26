using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public enum InGameSoundType
    {
        Fire = 0,
        reload = 1,
        explotion = 2,
        reflectBullet = 3,
        StartArea = 4,
        SceneChange = 5,
        Start = 6,
        Sucseece = 7 ,
        Fail = 8 ,
        Fall = 9 ,
        Landing = 10,
    }
    public enum BGMSceneType
    {
        Title = 0, //
        InGame = 1, //
        Result = 2, //
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
    public void PlaySE(InGameSoundType soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[(int)soundIndex]);
    public void PlaySE(int soundIndex)
        => _audioSESource.PlayOneShot(_audioSEClips[soundIndex]);
    public void PlayBGM(BGMSceneType soundIndex)
    {
        _audioBGMSource.clip = _audioBGMClips[(int)soundIndex];
        _audioBGMSource.Play();
    }

}
