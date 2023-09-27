using UnityEngine;

public class DashPanel : MonoBehaviour, IDamageble
{
    [SerializeField] float _addSpeed = 100.0f;
    [SerializeField] SpriteRenderer _spriteRenderer = null;

    public void Hit()
    {
        GameManager.Instance.AddSpeed(_addSpeed);
    }

    void IDamageble.UIShow(ScoreShow scoreShow)
    {
        //throw new System.NotImplementedException();
    }
}
