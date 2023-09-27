using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("アニメーション設定")]
    [SerializeField] private PlayerAnim _playerAnim;

    [Header("移動設定")]
    [SerializeField] private PlayerMove _playerMove;

    [Header("UI設定")]
    [SerializeField] private PlayerUI _playerUI;

    [SerializeField] private CameraControl _cameraControl;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Animator _anim;

    public Animator Animator => _anim;
    public PlayerAnim PlayerAnim => _playerAnim;
    public PlayerMove PlayerMove => _playerMove;
    public PlayerUI PlayerUI => _playerUI;

    public Rigidbody Rigidbody => _rb;

    void Start()
    {
        _playerAnim.Init(this);
        _playerMove.Init(this);
        _playerUI.Init(this);
    }


    void Update()
    {
        _playerUI.SetUI();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        _playerMove.Move(h);
        _playerMove.Rotate(h);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IDamageble>(out IDamageble hit);

        if(hit!=null)
        {
            hit.Hit();
            _cameraControl.Shake();
            _playerAnim.HitAnim();
        }
    }


}
