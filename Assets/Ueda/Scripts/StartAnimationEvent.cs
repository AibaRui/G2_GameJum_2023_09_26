using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationEvent : MonoBehaviour
{
    [SerializeField] string nextScene = "Game";
    public void StartEvent()
    {
        SceneController.Instance.FadeAndNextScene(nextScene);
    }
}
