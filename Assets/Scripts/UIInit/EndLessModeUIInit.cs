using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLessModeUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("StopUI"); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { FindObjectOfType<IGameScene>().GameStop(true); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("EndlessModeUI"); });
        mUISystem.SetText(transform.GetChild(1).GetChild(0).GetComponent<Text>(), transform.GetChild(2).GetChild(0).GetComponent<Text>());
    }
   
}
