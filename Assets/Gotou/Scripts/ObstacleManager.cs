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

    public void Hit()
    {
        // NowGearが4以上の時のみ破壊できる
        if (GameManager.Instance.NowGear == GameManager.Gear.Gear4 || GameManager.Instance.NowGear == GameManager.Gear.Gear5)
        {
            AudioManager.Instance.PlaySE(AudioManager.SEType.Destruction);
            // スコアの加算
            GameManager.Instance.AddSpeed(_addSpeed);
            // 加速処理
            GameManager.Instance.AddScore(_score);
            // 破壊時に透明にする
            _spriteRenderer.color = new Color(0, 0, 0, 0);
            // エフェクトの生成、再生
            ParticleSystem particle = Instantiate(_breakEffect, _spriteTransform.transform.position, _breakEffect.transform.rotation);
            particle.Play();
            Destroy(this.gameObject, _waitTime);
        }
        else   // それ以下の時は減速する
        {
            AudioManager.Instance.PlaySE(AudioManager.SEType.Clash);
            // 減速処理
            GameManager.Instance.AddSpeed(_decreaseSpeed);
            // 煙の生成、再生
            ParticleSystem particle = Instantiate(_smokeEffect, _spriteTransform.transform.position, _smokeEffect.transform.rotation);
            particle.Play();
        }
    }

    void IDamageble.UIShow(ScoreShow scoreShow)
    {
        //throw new System.NotImplementedException();
    }
}
