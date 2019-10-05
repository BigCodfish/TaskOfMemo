using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SkinChooseUI"); });
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SetSkin(0); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SkinChooseUI"); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SetSkin(1); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SkinChooseUI"); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SetSkin(2); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SkinChooseUI"); });
        transform.GetChild(3).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SetSkin(3); });
    }
    
}
