using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UISystem: MonoBehaviour
{
    public Dictionary<string,GameObject> mGameObjects = new Dictionary<string,GameObject>();
    private Text[] mTexts;

    public void SetText(params Text[] texts)
    {
        mTexts = new Text[texts.Length];
        mTexts = texts;
    }

    public void DataText(int[] datas)
    {
        //Debug.Log(datas.Length);
        if (mTexts == null) return;
        for (int i = 0; i < mTexts.Length; i++)
        {
            //Debug.Log(mTexts.Length);
            if(mTexts.Length <= datas.Length) mTexts[i].text = Convert.ToString(datas[i]);
        }
        
    }

    public void SceneSwitchButton(string sceneName)
    {
        FindObjectOfType<IGameScene>().Exit();
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
            //Debug.Log("Add UI");            
            mGameObjects.Add(uiName, go);
            //Debug.Log("Add Success:" + mGameObjects.ContainsKey(uiName));
        }
            
    }

    public void RePlayButton()
    {
        FindObjectOfType<IGameScene>().RePlay();
    }

    public void UIHideButton(string uiName)
    {
        //Debug.Log(uiName + mGameObjects.ContainsKey(uiName));
        if (!mGameObjects.ContainsKey(uiName))
        {
            GameObject temp = GameObject.Find(uiName + "(Clone)");
            if (temp != null) mGameObjects.Add(uiName, temp);
        }
        mGameObjects[uiName].SetActive(false);
    }

    public void SetSkin(int id)
    {
        Debug.Log(id);
        GlobalSetting setting = FindObjectOfType<GlobalSetting>();
        setting.currentBodySkin = setting.bodySkins[id];
        setting.currentHeadSkin = setting.headSkins[id];
    }

    public void SetVolume(string type, float volume)
    {
        GlobalSetting setting = FindObjectOfType<GlobalSetting>();
        if (type == "Music") setting.musicVolume = volume;
        else setting.soundVolume = volume;
    }

    public void SetLevel(int level,bool value)
    {
        GlobalSetting setting = FindObjectOfType<GlobalSetting>();
        if (value) setting.level = level;
    }

    public void SetAudioState(string type,bool value)
    {
        GlobalSetting setting = FindObjectOfType<GlobalSetting>();
        if (type == "Music") setting.musicOn = value;
        else setting.soundOn = value;
    }

    public void DeleteUIDictionary()
    {
        mGameObjects = new Dictionary<string, GameObject>();
    }
}
