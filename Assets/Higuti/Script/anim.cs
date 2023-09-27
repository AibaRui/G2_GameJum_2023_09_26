using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    [SerializeField] AudioSource _bgm;
    public void animeve()
    {

    }
    private void Start()
    {
        _bgm.Play();
    }
}
