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
    [SerializeField] private int _makeDashPersent = 20;

    [Header("オブジェクトの生成量")]
    [SerializeField, Range(0f, 10f)]int[] _setNums;

    private bool _isDash = false;

    public void Init(Transform parent)
    {
        Setting(parent);
    }

    private void Setting(Transform parent)
    {
        int setNum = _setNums[(int)GameManager.Instance.NowGear];
        print("setnum" + setNum);
        for (int i = 0; i < setNum; i++)
        {
            int randomInt = Random.Range(0, 100);
            if ( _makeDashPersent > randomInt && !_isDash)
            {
                var go = Instantiate(_dashPanel);
                int randamX = (int)Random.Range(-_side, _side);
                go.transform.SetParent(_obstaclePos[i]);
                go.transform.localPosition = Vector3.zero + new Vector3(randamX, 0, 0);
                go.transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(75, 0, 0));
                _isDash = true;
            }
            else
            {
                int objR = Random.Range(0, _obstacles.Count);
                Debug.Log("Spown" + i);
                var go = Instantiate(_obstacles[objR]);
                go.transform.SetParent(_obstaclePos[i]);
                int randamX = (int)Random.Range(-_side, _side);
                go.transform.localPosition = Vector3.zero + new Vector3(randamX, 0, 0);
            }
        }
    }
}
