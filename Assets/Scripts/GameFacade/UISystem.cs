using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISystem: MonoBehaviour
{
    private Dictionary<string,GameObject> mGameObjects = new Dictionary<string,GameObject>();

    public void SceneSwitchButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UISwitchButton(string uiName)
    {
        if (mGameObjects.ContainsKey(uiName))
            mGameObjects[uiName].SetActive(true);
        else
        {
            //Debug.Log("UIPrefabs/" + uiName);
            GameObject go = Instantiate(Resources.Load("UIPrefabs/" + uiName), GameObject.Find("Canvas").transform) as GameObject;
            mGameObjects.Add(uiName, go);
        }
            
    }
    public void UIHideButton(string uiName)
    {
        mGameObjects[uiName].SetActive(false);
    }
}
