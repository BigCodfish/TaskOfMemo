using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        //haveInit = true;
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("SimpleScene"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("LevelChooseUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("EndlessScene"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("ColorScene"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate() { mUISystem.UIHideButton("ModeChoosePanel"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
    }
}
