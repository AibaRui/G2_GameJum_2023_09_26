using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [Header("移動最高速度")]
    [SerializeField] private float _maxSpeed = 3;

    [Header("加速度")]
    [SerializeField] private float _addSpeed;

    [Header("原則度")]
    [SerializeField] private float _slowSpeed;

    private PlayerControl _playerControl;
    public void Init(PlayerControl playerControl)
    {
        _playerControl = playerControl;
    }

    public void Move(float h)
    {
        if (h != 0)
        {
            _playerControl.Rigidbody.AddForce(Vector3.right*h*_addSpeed);

            if(_playerControl.Rigidbody.velocity.x> _maxSpeed)
            {
                _playerControl.Rigidbody.velocity = new Vector3(_maxSpeed, 0, 0);
            }
            else if(_playerControl.Rigidbody.velocity.x<-_maxSpeed)
            {
                _playerControl.Rigidbody.velocity = new Vector3(-_maxSpeed, 0, 0);
            }
        }
        else
        {
            if (_playerControl.Rigidbody.velocity.x == 0) return;

                if (_playerControl.Rigidbody.velocity.x > 0)
            {
                _playerControl.Rigidbody.AddForce(Vector3.left * _slowSpeed);

                if (_playerControl.Rigidbody.velocity.x < 0)
                {
                    _playerControl.Rigidbody.velocity = Vector3.zero;
                }

            }
            else if (_playerControl.Rigidbody.velocity.x < 0)
            {
                _playerControl.Rigidbody.AddForce(Vector3.right * _slowSpeed);

                if (_playerControl.Rigidbody.velocity.x > 0)
                {
                    _playerControl.Rigidbody.velocity = Vector3.zero;
                }
            }
        }   //減速処理
    }

}
