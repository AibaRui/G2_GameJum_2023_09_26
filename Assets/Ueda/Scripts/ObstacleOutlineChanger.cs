using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ObstacleOutlineChanger : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer>_obstacleSprites;
    [SerializeField] Color _breakableColor = Color.gray;
    //private void Awake()
    //{
    //    Instance = this ;
    //    _obstacleSprites = _obstacles.Select(x => x.GetComponent<SpriteRenderer>()).ToList();
    //}

    void OnEnable()
    {
        _obstacleSprites.ForEach(x => x.color = _breakableColor);
    }
    public void ActiveObstacleOutLine(int index)
    {
        _obstacleSprites[index].color = Color.white;
    }

}
