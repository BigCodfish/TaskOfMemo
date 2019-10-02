using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeChooseUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        Debug.Log("Init");
        transform.GetChild(4).GetComponent<Button>().onClick.AddListener(delegate() { mUISystem.UIHideButton("ModeChoosePanel"); });
    }
}
