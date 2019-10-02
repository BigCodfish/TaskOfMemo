﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate(){mUISystem.UISwitchButton("ModeChoosePanel");});
    }

}
