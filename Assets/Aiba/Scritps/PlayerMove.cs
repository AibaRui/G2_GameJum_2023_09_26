using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [Header("各ギアのX速度")]
    [SerializeField] private float[] _maxSpeeds = new float[6];

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
        _car.rotation = Quaternion.Euler(_maxRotate * h);
    }


    public void Move(float h)
    {
        _playerControl.Rigidbody.velocity = Vector3.right * h * _maxSpeeds[(int)GameManager.Instance.NowGear];
    }

}
