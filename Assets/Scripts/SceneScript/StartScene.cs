using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : IGameScene
{    
    public override void Init()
    {
        //Debug.Log("InitStartScene");
        uISystem = new UISystem();
    }
    public override void SceneUpdate()
    {
        foreach (string item in uISystem.mGameObjects.Keys)
        {
            //Debug.Log(uISystem.mGameObjects[item]);
        }
    }    
    //public override void Exit()
    //{
    //    //uISystem.DeleteUIDictionary();
    //}
}
