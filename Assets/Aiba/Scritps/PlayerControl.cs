using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("アニメーション設定")]
    [SerializeField] private PlayerAnim _playerAnim;

    [Header("移動設定")]
    [SerializeField] private PlayerMove _playerMove;

    [SerializeField] private Rigidbody _rb;


    public PlayerAnim PlayerAnim => _playerAnim;
    public PlayerMove PlayerMove => _playerMove;


    public Rigidbody Rigidbody => _rb;

    void Start()
    {
        _playerAnim.Init(this);
        _playerMove.Init(this);
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        _playerMove.Move(h);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IDamageble>(out IDamageble hit);

        if(hit!=null)
        {
            hit.Hit();
        }
    }


}
