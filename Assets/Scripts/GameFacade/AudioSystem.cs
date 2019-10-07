using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    private static AudioSystem _instance = null;
    public AudioClip[] propAudios;
    public AudioSource bgm, prop, button;
    private GlobalSetting globalSetting;

    //共有的唯一的，全局访问点
    public static AudioSystem Instance
    {
        get
        {
            if (_instance == null)
            {    //查找场景中是否已经存在单例
                _instance = GameObject.FindObjectOfType<AudioSystem>();
                if (_instance == null)
                {    //创建游戏对象然后绑定单例脚本
                    GameObject go = new GameObject("AudioSystem");
                    _instance = go.AddComponent<AudioSystem>();
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        globalSetting = FindObjectOfType<GlobalSetting>();
    }

    private void Update()
    {
        button.mute = !globalSetting.soundOn;
        prop.mute = !globalSetting.soundOn;
        bgm.mute = !globalSetting.musicOn;

        bgm.volume = globalSetting.musicVolume;
        prop.volume = globalSetting.soundVolume;
        button.volume = globalSetting.soundVolume;
    }

    public void PlayPropAudio(int id)
    {
        prop.clip = propAudios[id];
        prop.Play();
    }

    public void PlayButtonAudio()
    {
        button.Play();
    }
}
