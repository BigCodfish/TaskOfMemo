using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IUIInit : MonoBehaviour
{
    protected virtual void UIEventInit() { }
    protected UISystem mUISystem;
    public bool haveInit = false;

    private void Start()
    {
        mUISystem = FindObjectOfType<IGameScene>().uISystem;
        if(!haveInit) UIEventInit();
    }
}
