using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObstacleSet : MonoBehaviour
{
    [Header("��Q����u���ʒu")]
    [SerializeField] private List<Transform> _obstaclePos = new List<Transform>();

    [Header("�}�b�v�̒[")]
    [SerializeField] private float _side = 4;

    [Header("��Q��")]
    [SerializeField] private List<GameObject> _obstacles = new List<GameObject>();

    [Header("�_�b�V���p�l��")]
    [SerializeField] private GameObject _dashPanel;

    [Header("�_�b�V���p�l�����o���m��(?/100)")]
    [SerializeField] private int _dashP = 2;

    private bool _isDash = false;

    public void Init(Transform parent)
    {
        Setting(parent);
    }

    private void Setting(Transform parent)
    {
        int setNum = 0;
        switch (GameManager.Instance.NowGear)
        {
            case GameManager.Gear.Gear0:
                setNum = 3;
                break;
            case GameManager.Gear.Gear1:
                setNum = 3;
                break;
            case GameManager.Gear.Gear2:
                setNum = 2;
                break;
            case GameManager.Gear.Gear3:
                setNum = 2;
                break;
            case GameManager.Gear.Gear4:
                setNum = 8;
                break;
            case GameManager.Gear.Gear5:
                setNum = 8;

                break;
        }

        for (int i = 0; i < setNum; i++)
        {
            int r = Random.Range(0, 100);

            if (r > _dashP)
            {
                int objR = Random.Range(0, _obstacles.Count);
                Debug.Log("Spown"+i);
                var go = Instantiate(_obstacles[objR]);
                go.transform.SetParent(_obstaclePos[i]);
                int randamX = (int)Random.Range(-_side, _side);
                go.transform.localPosition = Vector3.zero + new Vector3(randamX, 0, 0);
            }
            else
            {
                if (_isDash) return;

                var go = Instantiate(_dashPanel);
                int randamX = (int)Random.Range(-_side, _side);
                go.transform.SetParent(_obstaclePos[i]);
                go.transform.localPosition = Vector3.zero + new Vector3(randamX, 0, 0);
                go.transform.GetChild(0).transform.localRotation = Quaternion.Euler(new Vector3(75,0,0));
                _isDash = true;
            }
        }
    }
}
