using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameScene : MonoBehaviour
{
    public virtual void Init() { }
    public virtual void StateUpdate() { }
    public virtual void Exit() { }
    public UISystem uISystem;

}
