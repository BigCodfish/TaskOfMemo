using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : IGameScene
{    
    public override void Init()
    {
        uISystem = new UISystem();
    }
}
