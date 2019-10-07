using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameScene : MonoBehaviour
{
    public virtual void Init() { }
    public virtual void SceneUpdate() { }
    public virtual void Exit() { /*Debug.Log("No Override Exit");*/ }
    public virtual void RePlay() { }
    public bool haveStop = false;
    [HideInInspector] public UISystem uISystem;
    [HideInInspector] public Recorder recorder;

    public bool haveEnd = false;
    protected bool gameResult;

    public virtual void SetList(GameObject go) { }

    public void SetResult(bool result)
    {
        haveEnd = true;
        gameResult = result;
    }
    public virtual void GameStop(bool value)
    {
        haveStop = value;
    }

}
