using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDecoration : MonoBehaviour
{
    [Header("装飾品を置く位置_左")]
    [SerializeField] private List<Transform> _obstaclePosLeft = new List<Transform>();

    [Header("装飾品を置く位置_右")]
    [SerializeField] private List<Transform> _obstaclePosRight = new List<Transform>();

    [Header("装飾品_左側")]
    [SerializeField] private List<GameObject> _obstaclesLeft = new List<GameObject>();

    [Header("装飾品_右側")]
    [SerializeField] private List<GameObject> _obstaclesRight = new List<GameObject>();

    public void Init(Transform parent)
    {
        SpownLeft(parent);
        SpownRight(parent);
    }

    private void SpownLeft(Transform parent)
    {
        foreach (var pos in _obstaclePosLeft)
        {
            int objR = Random.Range(0, _obstaclesLeft.Count);

            var go = Instantiate(_obstaclesLeft[objR]);
            Vector3 setPos = pos.position;
            go.transform.position = setPos;

            go.transform.SetParent(parent);
        }
    }

    private void SpownRight(Transform parent)
    {
        foreach (var pos in _obstaclePosRight)
        {
            int objR = Random.Range(0, _obstaclesRight.Count);

            var go = Instantiate(_obstaclesRight[objR]);
            Vector3 setPos = pos.position;
            go.transform.position = setPos;

            go.transform.SetParent(parent);
        }
    }

}
