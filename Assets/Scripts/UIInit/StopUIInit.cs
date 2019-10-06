using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(1, value));
        transform.GetChild(0).GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(2, value));
        transform.GetChild(0).GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetLevel(3, value));
        transform.GetChild(1).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetAudioState("Music", value));
        transform.GetChild(2).GetComponent<Toggle>().onValueChanged.AddListener((bool value) => mUISystem.SetAudioState("Sound", value));
        transform.GetChild(3).GetComponent<Slider>().onValueChanged.AddListener((float value) => mUISystem.SetVolume("Music", value));        
        transform.GetChild(4).GetComponent<Slider>().onValueChanged.AddListener((float value) => mUISystem.SetVolume("Sound", value));
        switch (SceneManager.GetActiveScene().name)
        {
            case "SimpleScene":
                transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("SimpleModeUI"); });
                break;
            case "EndlessScene":
                transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("EndlessModeUI"); });
                break;
            case "ColorScene":
                transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UISwitchButton("ColorModeUI"); });
                break;
            default:
                Debug.Log("Please add event to StopUIInit");
                break;
        }        
        transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { FindObjectOfType<IGameScene>().GameStop(false); });
        transform.GetChild(5).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("StopUI"); });
        transform.GetChild(6).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("StartScene"); });
    }
}
