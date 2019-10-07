using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLessModeUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("StopUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { FindObjectOfType<IGameScene>().GameStop(true); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("EndlessModeUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        mUISystem.SetText(transform.GetChild(1).GetChild(0).GetComponent<Text>(), transform.GetChild(2).GetChild(0).GetComponent<Text>());
    }
   
}
