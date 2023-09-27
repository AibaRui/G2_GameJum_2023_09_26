using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [Header("�J����")]
    [SerializeField] private CinemachineVirtualCamera _camera;

    [Header("�J�����̋���")]
    [SerializeField] private List<float> _cameraDis = new List<float>();

    [Header("�J������FOV")]
    [SerializeField] private List<float> _cameraFOV = new List<float>();

    [Header("�J�����̌X���p�x")]
    [SerializeField] private float _dutchMax;

    [Header("�J�����̌X���̉�]���x")]
    [SerializeField] private float _dutchChangeSpeed = 0.01f;

    [Header("�J�����̗h�炷��")]
    [SerializeField] private float _shakePower = 0.3f;

    [Header("�J�����̗h�炷��_Gear5�̎�")]
    [SerializeField] private float _shakePowerGear5 = 0.3f;

    [SerializeField] private CinemachineImpulseSource Source;

    private float _setDutch = 0;

    private bool _isEndGame = false;

    private CinemachineTransposer _cinemachineTransposer;

    private void Awake()
    {
        _cinemachineTransposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (!_isEndGame)
        {
            SetFOV();
            ChangeDutch(h);
        }
        else
        {
            ChangeDutch(0);
        }

    }

    public void EndGame()
    {
        _isEndGame = true;
    }

    public void Shake()
    {
        Source.m_ImpulseDefinition.m_TimeEnvelope.m_AttackTime = 0.2f;
        Source.m_ImpulseDefinition.m_TimeEnvelope.m_DecayTime = 0.2f;

        float setPower = 0;

        if (GameManager.Instance.NowGear != GameManager.Gear.Gear5)
        {
            setPower = _shakePowerGear5;
        }
        else
        {
            setPower = _shakePower;
        }
        Source.GenerateImpulse(new Vector3(0, setPower, 0));
    }


    private void ChangeDutch(float h)
    {
        if (h > 0)
        {
            if (_setDutch < _dutchMax)
            {
                _setDutch += _dutchChangeSpeed;
                if (_setDutch > _dutchMax)
                {
                    _setDutch = _dutchMax;
                }
            }
        }
        else if (h < 0)
        {
            if (_setDutch > -_dutchMax)
            {
                _setDutch -= _dutchChangeSpeed;
                if (_setDutch < -_dutchMax)
                {
                    _setDutch = -_dutchMax;
                }
            }
        }
        else
        {
            if (_setDutch > 0)
            {
                _setDutch -= _dutchChangeSpeed;
                if (_setDutch < 0)
                {
                    _setDutch = 0;
                }
            }
            else if (_setDutch < 0)
            {
                _setDutch += _dutchChangeSpeed;
                if (_setDutch > 0)
                {
                    _setDutch = 0;
                }
            }
        }
        _camera.m_Lens.Dutch = _setDutch;
    }



    public void SetFOV()
    {
        switch (GameManager.Instance.NowGear)
        {
            case GameManager.Gear.Gear0:
                _cinemachineTransposer.m_FollowOffset.z = _cameraDis[0];
                _camera.m_Lens.FieldOfView = _cameraFOV[0];
                break;
            case GameManager.Gear.Gear1:
                _cinemachineTransposer.m_FollowOffset.z = _cameraDis[1];
                _camera.m_Lens.FieldOfView = _cameraFOV[1];
                break;
            case GameManager.Gear.Gear2:
                _cinemachineTransposer.m_FollowOffset.z = _cameraDis[2];
                _camera.m_Lens.FieldOfView = _cameraFOV[2];
                break;
            case GameManager.Gear.Gear3:
                _cinemachineTransposer.m_FollowOffset.z = _cameraDis[3];
                _camera.m_Lens.FieldOfView = _cameraFOV[3];
                break;
            case GameManager.Gear.Gear4:
                _cinemachineTransposer.m_FollowOffset.z = _cameraDis[4];
                _camera.m_Lens.FieldOfView = _cameraFOV[4];
                break;
        }
    }
}
