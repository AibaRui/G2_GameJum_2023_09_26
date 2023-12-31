using UnityEngine;

public class DecorationManager : MonoBehaviour, IDamageble
{
    [SerializeField] int _score = 0;
    [SerializeField] ParticleSystem _breakEffect = null;
    [SerializeField] float _waitTime = 0;
    [SerializeField] SpriteRenderer _spriteRenderer = null;
    [SerializeField] Transform _spriteTransform = null;

    public void Hit()
    {
        // NowGearが5の時のみ破壊できる
        if (GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            GameManager.Instance.AddScore(_score);
            _spriteRenderer.color = new Color(0, 0, 0, 0);
            ParticleSystem particle = Instantiate(_breakEffect, _spriteTransform.transform.position, _breakEffect.transform.rotation);
            particle.Play();
            Destroy(this.gameObject, _waitTime);
        }
    }

    void IDamageble.UIShow(ScoreShow scoreShow)
    {
        //throw new System.NotImplementedException();
    }
}
