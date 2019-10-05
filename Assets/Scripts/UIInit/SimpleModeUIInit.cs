using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleModeUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("StopUI"); });        
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { FindObjectOfType<SimpleScene>().GameStop(); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SimpleModeUI"); });
        mUISystem.SetText(transform.GetChild(1).GetChild(0).GetComponent<Text>(), transform.GetChild(2).GetChild(0).GetComponent<Text>(), transform.GetChild(3).GetChild(0).GetComponent<Text>());
    }
}
