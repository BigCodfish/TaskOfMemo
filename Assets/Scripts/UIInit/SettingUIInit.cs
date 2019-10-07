using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(1, value));
        transform.GetChild(0).GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(2, value));
        transform.GetChild(0).GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(3, value));
        transform.GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetAudioState("Music", value));
        transform.GetChild(2).GetComponent<Slider>().onValueChanged.AddListener((float value) => mUISystem.SetVolume("Music",value));
        transform.GetChild(3).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetAudioState("Sound", value));
        transform.GetChild(4).GetComponent<Slider>().onValueChanged.AddListener((float value) => mUISystem.SetVolume("Sound", value));
        transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SettingUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(6).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("SkinChooseUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });

        transform.GetChild(2).GetComponent<Slider>().value = FindObjectOfType<GlobalSetting>().musicVolume;
        transform.GetChild(4).GetComponent<Slider>().value = FindObjectOfType<GlobalSetting>().soundVolume;

        transform.GetChild(1).GetComponent<Toggle>().isOn = FindObjectOfType<GlobalSetting>().musicOn;
        transform.GetChild(3).GetComponent<Toggle>().isOn = FindObjectOfType<GlobalSetting>().soundOn;

        switch (FindObjectOfType<GlobalSetting>().level)
        {
            case 1:
                transform.GetChild(0).GetChild(0).GetComponent<Toggle>().isOn = true;
                break;
            case 2:
                transform.GetChild(0).GetChild(1).GetComponent<Toggle>().isOn = true;
                break;
            case 3:
                transform.GetChild(0).GetChild(2).GetComponent<Toggle>().isOn = true;
                break;
            default:
                break;
        }
        
    }
}
