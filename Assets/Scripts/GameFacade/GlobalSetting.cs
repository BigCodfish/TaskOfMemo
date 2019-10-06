using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSetting : MonoBehaviour
{
    public Sprite currentHeadSkin;
    public Sprite currentBodySkin;
    public Sprite[] headSkins;
    public Sprite[] bodySkins;
    public bool musicOn = true;
    public bool soundOn = true;
    public float musicVolume = 1;
    public float soundVolume = 1;    
    public int level = 2;

    private static GlobalSetting _instance = null;

    //共有的唯一的，全局访问点
    public static GlobalSetting Instance
    {
        get
        {
            if (_instance == null)
            {    //查找场景中是否已经存在单例
                _instance = GameObject.FindObjectOfType<GlobalSetting>();
                if (_instance == null)
                {    //创建游戏对象然后绑定单例脚本
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GlobalSetting>();
                }
            }
            return _instance;
        }
    }

    private void Start()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
        currentBodySkin = bodySkins[0];
        currentHeadSkin = headSkins[0];
    }
}
