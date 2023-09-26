using UnityEngine;

public class DashPanel : MonoBehaviour, IDamageble
{
    [SerializeField] float _addSpeed = 100.0f;

    public void Hit()
    {
        GameManager.Instance.AddSpeed(_addSpeed);
    }
}
