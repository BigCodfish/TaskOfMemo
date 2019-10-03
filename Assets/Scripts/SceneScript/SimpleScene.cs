using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : IGameScene
{
    public override void Init()
    {
        uISystem = new UISystem();
    }
}
