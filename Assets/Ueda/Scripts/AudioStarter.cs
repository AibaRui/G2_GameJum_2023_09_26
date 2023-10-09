using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarter : MonoBehaviour
{
    [SerializeField] AudioManager.BGMType _playBGM;
    void Start()
    {
        AudioManager.Instance.PlayBGM(_playBGM);
    }

}
