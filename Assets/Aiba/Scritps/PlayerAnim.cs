using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerAnim
{
    [SerializeField] private string _hitAnim;

    private PlayerControl _playerControl;
    public void Init(PlayerControl playerControl)
    {
        _playerControl = playerControl;
    }


    public void HitAnim()
    {
        _playerControl.Animator.Play(_hitAnim);
    }

}
