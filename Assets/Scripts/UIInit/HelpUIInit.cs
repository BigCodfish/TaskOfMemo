using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(4).GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener((bool isOn) => this.OnToggleClick(isOn, 0));
        transform.GetChild(4).GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener((bool isOn) => this.OnToggleClick(isOn, 1));
        transform.GetChild(4).GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((bool isOn) => this.OnToggleClick(isOn, 2));
        transform.GetChild(4).GetChild(3).GetComponent<Toggle>().onValueChanged.AddListener((bool isOn) => this.OnToggleClick(isOn, 3));
        for (int i = 1; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("HelpUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
    }

    private void OnToggleClick(bool isOn ,int id)
    {
        transform.GetChild(id).gameObject.SetActive(isOn);
    }
}
