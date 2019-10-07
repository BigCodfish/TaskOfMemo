using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("RiskScene1"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("RiskScene2"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("LevelChooseUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
    }
    
}
