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

    [Header("最大角度")]
    [SerializeField] private Vector3 _maxRotate = new Vector3(0, 0, 20);

    [Header("中央のX座標")]
    [SerializeField] private float _endX = 0;

    [Header("終了時の移動速度")]
    [SerializeField] private float _speedEnd = 200;

    [SerializeField] private Transform _car;

    [SerializeField] private float _rotateSpeed = 200;

    private PlayerControl _playerControl;
    public void Init(PlayerControl playerControl)
    {
        _playerControl = playerControl;
    }

    public bool MoveEnd()
    {
        Vector3 endPos = new Vector3(_endX, _car.transform.position.y, _car.transform.position.z);
        Vector3 dir = endPos - _car.position;
        _playerControl.Rigidbody.AddForce(dir.normalized * _speedEnd);

        if (Mathf.Abs(_car.transform.position.x - endPos.x) < 0.1f)
        {
            _playerControl.Rigidbody.velocity = Vector3.zero;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Rotate(float h)
    {
        Vector3 defultR = _car.eulerAngles;
        defultR.z = 0;
        Quaternion setR = default;

        if (h == 0)
        {
            setR = Quaternion.Euler(defultR);
        }
        else
        {
            if (h > 0)
            {
                setR = Quaternion.Euler(defultR + (-_maxRotate));
            }
            else
            {
                setR = Quaternion.Euler(defultR + _maxRotate);
            }
        }

        float time = Time.deltaTime * _rotateSpeed;

        _car.rotation = Quaternion.RotateTowards(_car.rotation, setR, time);
    }


    public void Move(float h)
    {
        if (h != 0)
        {
            _playerControl.Rigidbody.AddForce(Vector3.right * h * _addSpeed);

            if (_playerControl.Rigidbody.velocity.x > _maxSpeed)
            {
                _playerControl.Rigidbody.velocity = new Vector3(_maxSpeed, 0, 0);
            }
            else if (_playerControl.Rigidbody.velocity.x < -_maxSpeed)
            {
                _playerControl.Rigidbody.velocity = new Vector3(-_maxSpeed, 0, 0);
            }
        }
        else
        {
            if (_playerControl.Rigidbody.velocity.x == 0)
            {
                _playerControl.Rigidbody.velocity = Vector3.zero;
                return;
            }

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
