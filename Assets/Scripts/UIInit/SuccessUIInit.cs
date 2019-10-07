using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SuccessUIInit : IUIInit
{
    protected override void UIEventInit()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "RiskScene1":
                transform.GetChild(0).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("RiskScene2"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
                break;
            default:
                break;
        }
        
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.RePlayButton(); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.UIHideButton("SuccessUI"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
        transform.GetChild(2).GetComponent<Button>().onClick.AddListener(delegate () { mUISystem.SceneSwitchButton("StartScene"); FindObjectOfType<AudioSystem>().PlayButtonAudio(); });
    }
    
}
