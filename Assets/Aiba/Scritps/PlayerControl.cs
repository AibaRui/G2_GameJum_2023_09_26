using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables; //Timelineの制御に必要


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

    [Header("終わりのTimeLine_Gear5")]
    [SerializeField] private PlayableDirector _timeLineGear5;

    [Header("終わりのTimeLine_Gear4")]
    [SerializeField] private PlayableDirector _timeLineGear4;

    [Header("終わりのTimeLine_Gearその他")]
    [SerializeField] private PlayableDirector _timeLineGearOther;

    [Header("風の音")]
    [SerializeField] private ParticleSystem _window;

    [SerializeField] private CameraControl _cameraControl;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Animator _anim;


    private bool _isPlay = false;
    private bool _isMoveEnd = false;


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

            if(GameManager.Instance.NowGear==GameManager.Gear.Gear5)
            {
                if(!_window.gameObject.activeSelf)
                {
                    _window.gameObject.SetActive(true);
                    _window.Play();
                }
            }

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
            if (!_isMoveEnd)
            {
                if (_playerMove.MoveEnd())
                {
                    _isMoveEnd = true;
                }
            }

            if (!_isPlay && _isMoveEnd)
            {
                StartCoroutine(PlayTimeLine());
            }


            _playerMove.Rotate(0);
        }
    }

    IEnumerator PlayTimeLine()
    {
        _isPlay = true;
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);

        if (GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            _timeLineGear5.gameObject.SetActive(true);
            _timeLineGear5.Play();
        }
        else if (GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            _timeLineGear4.gameObject.SetActive(true);
            _timeLineGear4.Play();
        }
        else
        {
            _timeLineGearOther.gameObject.SetActive(true);
            _timeLineGearOther.Play();
        }
    }

    public void EndGame()
    {
        _isEndGame = true;
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
