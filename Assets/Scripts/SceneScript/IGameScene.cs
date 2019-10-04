using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameScene : MonoBehaviour
{
    public virtual void Init() { }
    public virtual void SceneUpdate() { }
    public virtual void Exit() { }
    public UISystem uISystem;

    public bool haveEnd = false;
    protected bool gameResult;
    public bool reStart = false;
    public void SetResult(bool result)
    {
        haveEnd = true;
        gameResult = result;
    }    
}
