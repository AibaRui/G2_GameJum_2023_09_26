using UnityEngine;

public class ObstacleManager : MonoBehaviour, IDamageble
{
    [SerializeField] int _score = 0;
    [SerializeField] float _addSpeed = 1.0f;
    [SerializeField] float _decreaseSpeed = -1.0f;
    [SerializeField] ParticleSystem _breakEffect = null;
    [SerializeField] ParticleSystem _smokeEffect = null;
    [SerializeField] float _waitTime = 0;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] Transform _spriteTransform = null;

    private void Start()
    {
        Hit();
    }

    public void Hit()
    {
        // NowGear��4�ȏ�̎��̂ݔj��ł���
        if (GameManager.Instance.NowGear == GameManager.Gear.Gear4 || GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            // �X�R�A�̉��Z
            GameManager.Instance.AddSpeed(_addSpeed);
            // ��������
            GameManager.Instance.AddScore(_score);
            // �j�󎞂ɓ����ɂ���
            _spriteRenderer.color = new Color(0, 0, 0, 0);
            // �G�t�F�N�g�̐����A�Đ�
            ParticleSystem particle = Instantiate(_breakEffect, _spriteTransform.transform.position, _breakEffect.transform.rotation);
            particle.Play();
            Destroy(this.gameObject, _waitTime);
        }
        else   // ����ȉ��̎��͌�������
        {
            // ��������
            GameManager.Instance.AddSpeed(_decreaseSpeed);
            // ���̐����A�Đ�
            ParticleSystem particle = Instantiate(_smokeEffect, _spriteTransform.transform.position, _smokeEffect.transform.rotation);
            particle.Play();
        }
    }
}
