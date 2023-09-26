using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObstacleSet : MonoBehaviour
{
    [Header("障害物を置く位置")]
    [SerializeField] private List<Transform> _obstaclePos = new List<Transform>();


    [Header("マップの端")]
    [SerializeField] private float _side = 4;

    [Header("障害物")]
    [SerializeField] private List<GameObject> _obstacles = new List<GameObject>();

    [Header("ダッシュパネル")]
    [SerializeField] private GameObject _dashPanel;

    [Header("ダッシュパネルを出す確率(?/100)")]
    [SerializeField] private int _dashP = 2;

    private bool _isDash = false;

    public void Init(Transform parent)
    {
        Setting(parent);
    }

    private void Setting(Transform parent)
    {
        foreach(var pos in _obstaclePos)
        {

            int r = Random.Range(0, 100);

            if(r>_dashP)
            {
                int objR = Random.Range(0, _obstacles.Count);

                var go = Instantiate(_obstacles[objR]);
                float randamX = Random.Range(-_side, _side);
                Vector3 setPos = pos.position + new Vector3(randamX,0,0);
                go.transform.position = setPos;

                go.transform.SetParent(parent);
            }
            else
            {
                if (_isDash) return;

                var go = Instantiate(_dashPanel);
                float randamX = Random.Range(-_side, _side);
                Vector3 setPos = pos.position + new Vector3(randamX, 0, 0);
                go.transform.position = setPos;
                go.transform.SetParent(parent);
                _isDash = true;
            }
        }
    }
}
