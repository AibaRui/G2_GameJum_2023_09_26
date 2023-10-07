using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapControl : MonoBehaviour
{
    [Header("マップのプレハブ")]
    [SerializeField] private GameObject _mapPrefab;

    [Header("最初の経過地点")]
    [SerializeField] private Transform _firstGoalPos;

    [Header("初期マップ")]
    [SerializeField] private List<GameObject> _firstMaps = new List<GameObject>();

    [Header("速さ設定")]
    [SerializeField] private List<float> _speeds = new List<float>(4);




    [Header("確認用_マップのロール速度")]
    [SerializeField] private float _moveSpeed = 5;

    [Header("確認用")]
    [SerializeField] private List<GameObject> _maps = new List<GameObject>();

    [Header("確認用")]
    [SerializeField] private List<Rigidbody> _mapsRb = new List<Rigidbody>();

    private bool _isEndGame = false;

    private Transform _goalPos;

    private Transform _playerT;

    private void Awake()
    {
        _playerT = GameObject.FindGameObjectWithTag("Player").transform;
        _goalPos = _firstGoalPos;

        foreach (var map in _firstMaps)
        {
            _mapsRb.Add(map.GetComponent<Rigidbody>());
            _maps.Add(map);
        }
    }

    public void EndGame()
    {
        _isEndGame = true;
    }
    private void Update()
    {
        Check();
        SetSpeed();
        CheckDestroy();
    }

    private void FixedUpdate()
    {
        foreach (var rb in _mapsRb)
        {
            if (rb == null) return;
            rb.velocity = Vector3.back * _moveSpeed;
        }
    }

    public void SetSpeed()
    {
        var GM_ins = GameManager.Instance;
        if (GM_ins)
        {
            var speedRate = (GM_ins.NowGear != GameManager.Gear.Gear5) ?  (_speeds[(int)GM_ins.NowGear + 1] - _speeds[(int)GM_ins.NowGear]) * (GM_ins.CurrentSpeed / GameManager.GearSpeed[GM_ins.NowGear]) : 0 ;
            _moveSpeed = _speeds[(int)GM_ins.NowGear] + speedRate;
        }

    }

    public void Check()
    {
        float h = _goalPos.position.z - _playerT.position.z;

        if (Mathf.Abs(h) < 3f)
        {
            SpownNewMap();
        }
    }

    public void CheckDestroy()
    {
        if (_maps.Count <= 2) return;

        float h = _maps[0].transform.position.z - _playerT.position.z;

        if (h < -(_mapPrefab.transform.localScale.z / 2 + 2))
        {
            var go = _maps[0];
            _maps.RemoveAt(0);
            _mapsRb.RemoveAt(0);
            Destroy(go);
        }
    }

    public void SpownNewMap()
    {
        Vector3 pos = _maps[0].transform.position + new Vector3(0, 0, _mapPrefab.transform.localScale.z * 2);
        var go = Instantiate(_mapPrefab);
        go.transform.position = pos;

        if (!_isEndGame)
        {
            go.GetComponent<MapObstacleSet>().Init(go.transform);
            go.GetComponent<MapDecoration>().Init(go.transform);
        }

        _maps.Add(go);
        _mapsRb.Add(go.GetComponent<Rigidbody>());
        _goalPos = _maps[1].transform;
    }


}
