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

    [Header("当たり判定の設定")]
    [SerializeField] private PlayerCollider _playerCollider;

    [SerializeField] private CameraControl _cameraControl;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Animator _anim;




    private bool _isEndGame = false;

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
        _playerCollider.Init(this);
    }


    void Update()
    {
        if (!_isEndGame)
        {
            _playerUI.SetUI();
            _playerCollider.CheckCollider();
        }
    }

    private void FixedUpdate()
    {
        if (!_isEndGame)
        {
            float h = Input.GetAxisRaw("Horizontal");
            _playerMove.Move(h);
            _playerMove.Rotate(h);
        }
        else
        {
            if (_playerMove.MoveEnd())
            {
                gameObject.SetActive(false);
            }
            _playerMove.Rotate(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.NowGear != GameManager.Gear.Gear5)
        {
            other.gameObject.TryGetComponent<IDamageble>(out IDamageble hit);

            if (hit != null)
            {
                hit.Hit();
            }
        }

        _cameraControl.Shake();
        _playerAnim.HitAnim();
    }


}
