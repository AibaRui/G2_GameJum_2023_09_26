using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerUI 
{
    [Header("W’†ü‚ÌUI")]
    [SerializeField] private List< GameObject> _speedUI = new List<GameObject>();

    private PlayerControl _playerControl;
    public void Init(PlayerControl playerControl)
    {
        _playerControl = playerControl;
    }


    public void SetUI()
    {
        int setNum = 0;

        switch (GameManager.Instance.NowGear)
        {
            case GameManager.Gear.Gear0:
                setNum = 0;
                break;
            case GameManager.Gear.Gear1:
                setNum = 1;
                break;
            case GameManager.Gear.Gear2:
                setNum = 2;
                break;
            case GameManager.Gear.Gear3:
                setNum = 3;
                break;
            case GameManager.Gear.Gear4:
                setNum = 4;
                break;
        }

        if(!_speedUI[setNum].activeSelf)
        {
            _speedUI[setNum].SetActive(true);

            if(setNum!=0)
            {
                _speedUI[setNum-1].SetActive(false);
            }

        }
    }

}
