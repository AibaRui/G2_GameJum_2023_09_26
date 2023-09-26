using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] GameObject _mapPrefab = null;
    [SerializeField] Vector3 _loopPosition = Vector3.zero;
    [SerializeField] GameObject _obstaclePrefab = null;

    GameObject _moveMap = null;
    float _mapSpeed = 0;

    void Start()
    {
        MapGeneration();
    }

    void Update()
    {
        if (_moveMap.transform.position.z <= _loopPosition.z)
        {
            //Debug.Log(_moveMap.transform.position.z);
            MapGeneration();
        }
    }

    /// <summary>マップの生成</summary>
    void MapGeneration()
    {
        // マップの生成
        _moveMap = Instantiate(_mapPrefab, this.transform.position, this.transform.rotation);
    }

    /// <summary>障害物の生成</summary>
    void ObstacleGeneration()
    {
        Instantiate(_obstaclePrefab, new Vector3(Random.Range(0, 2), this.transform.position.y, this.transform.position.z), this.transform.rotation);
    }
}
