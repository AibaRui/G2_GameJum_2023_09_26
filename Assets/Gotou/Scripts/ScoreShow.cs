using UnityEngine;

public class ScoreShow : MonoBehaviour, IDamageble
{
    void Start()
    {

    }

    void Update()
    {

    }

    void IDamageble.Hit()
    {
        throw new System.NotImplementedException();
    }

    void IDamageble.UIShow(ScoreShow scoreShow)
    {
        throw new System.NotImplementedException();
    }
}
