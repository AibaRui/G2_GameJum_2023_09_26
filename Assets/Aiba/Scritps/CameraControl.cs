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
        float h = Input.GetAxis("Horizontal");

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
        _camera.m_Lens.Dutch = _dutchMax * h;
    }



    public void SetFOV()
    {
        _cinemachineTransposer.m_FollowOffset.z = _cameraDis[(int)GameManager.Instance.NowGear];
        var GM_ins = GameManager.Instance;
        var speedRate = (GM_ins.NowGear != GameManager.Gear.Gear5) ? (_cameraFOV[(int)GM_ins.NowGear + 1] - _cameraFOV[(int)GM_ins.NowGear]) * (GM_ins.CurrentSpeed / GameManager.GearSpeed[GM_ins.NowGear]) : 0;
        _camera.m_Lens.FieldOfView = _cameraFOV[(int)GM_ins.NowGear] + speedRate;

    }
}
