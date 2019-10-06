using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        //haveInit = true;
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("SimpleScene"); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("EndlessScene"); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("ColorScene"); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("ModeChoosePanel"); });
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate() { mUISystem.UIHideButton("ModeChoosePanel"); });
    }
}
