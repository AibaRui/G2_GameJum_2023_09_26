using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonSingletonAttacher : MonoBehaviour
{
    public void SceneFade(string next)
    {
        SceneController.Instance?.FadeAndNextScene(next);
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    var buttonEvent = GetComponent<Button>().onClick;
    //    var singletons = GameObject.FindObjectsOfType<SingletonBase<Component>>();
    //    for (int i = 0; i < buttonEvent?.GetPersistentEventCount(); i++)
    //    {
    //        print(buttonEvent?.GetPersistentEventCount());
    //        print(buttonEvent?.GetPersistentTarget(i));
    //        print(buttonEvent?.GetPersistentMethodName(i));
    //        var comp = buttonEvent?.GetPersistentTarget(i) as SingletonBase<SceneController>;
    //        if(comp == null) { continue; }
    //        var mName = buttonEvent?.GetPersistentMethodName(i);
    //        //buttonEvent.AddListener(singletons.Where((x) => x == comp).ToList().ForEach((x) => x.GetType().GetMethod(mName).Invoke(comp ,null)). ) ;
    //        //Delegate.CreateDelegate(comp.GetType() , comp.GetType().GetMethod(mName));
    //        buttonEvent.AddListener((UnityAction)Delegate.CreateDelegate(comp.GetType(), comp ,comp.GetType().GetMethod(mName))) ;

    //    }

    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
