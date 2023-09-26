using UnityEngine;

public class ObstacleManager : MonoBehaviour, IDamageble
{
    [SerializeField] int _score = 0;
    [SerializeField] float _addSpeed = 1.0f;
    [SerializeField] float _decreaseSpeed = -1.0f;
    [SerializeField] ParticleSystem _particle = null;
    [SerializeField] float _waitTime = 0;
    [SerializeField] SpriteRenderer _spriteRenderer = null;

    public void Hit()
    {
        if (GameManager.Instance.NowGear == GameManager.Gear.Gear4)
        {
            GameManager.Instance.AddSpeed(_addSpeed);
            GameManager.Instance.AddScore(_score);
            _spriteRenderer.color = new Color(0, 0, 0, 0);
            ParticleSystem particle = Instantiate(_particle, this.transform.position, this.transform.rotation);
            particle.Play();
            Destroy(this.gameObject, _waitTime);
        }
        else
        {
            GameManager.Instance.AddSpeed(_decreaseSpeed);
        }
    }
}
