using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("Level1"); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("Level2"); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("Level3"); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("Level4"); });
    }
    
}
