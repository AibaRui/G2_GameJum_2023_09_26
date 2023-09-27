using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBigCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.TryGetComponent<IDamageble>(out IDamageble hit);

        if (hit != null)
        {
            hit.Hit();
        }
    }

}
