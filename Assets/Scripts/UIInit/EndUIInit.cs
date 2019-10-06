using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        mUISystem.SetText(transform.GetChild(0).GetComponent<Text>());
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.RePlayButton(); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("EndUI"); });      
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("StartScene"); });        
    }
}
