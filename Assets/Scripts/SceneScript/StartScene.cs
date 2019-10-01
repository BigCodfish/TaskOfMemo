using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : IGameScene
{
    public Button[] buttonGroup;

    protected override void AddOnClick()
    {
        buttonGroup[0].onClick.AddListener(delegate() { });
    }
}
