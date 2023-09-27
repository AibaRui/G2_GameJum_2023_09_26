using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCollider
{
    [Header("Gear5‚ÌŽž‚ÌCollider‚ÌƒTƒCƒY")]
    [SerializeField] private GameObject _collider;
    
    private PlayerControl _playerControl;
    public void Init(PlayerControl playerControl)
    {
        _playerControl = playerControl;
    }

    public void CheckCollider()
    {
        if(GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            if(!_collider.activeSelf)
            {
                _collider.SetActive(true);
            }
        }
    }

}

