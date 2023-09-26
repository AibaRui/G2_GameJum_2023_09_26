using UnityEngine;

public class MapMove : MonoBehaviour
{
    [SerializeField] float _mapSpeed = 0;
    [SerializeField] float _destroyPosition = 0;

    void Start()
    {

    }

    void Update()
    {
        // マップの移動
        this.transform.position += -this.transform.forward * _mapSpeed;
    }
}
