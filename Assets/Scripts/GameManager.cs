using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private IGameScene mCurrentScene;

    private static GameManager _instance = null;

    //共有的唯一的，全局访问点
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {    //查找场景中是否已经存在单例
                _instance = GameObject.FindObjectOfType<GameManager>();
                if (_instance == null)
                {    //创建游戏对象然后绑定单例脚本
                    GameObject go = new GameObject("GameManager");
                    _instance = go.AddComponent<GameManager>();
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        mCurrentScene = FindObjectOfType<IGameScene>();
        mCurrentScene.Init();
        DontDestroyOnLoad(this.gameObject);        
    }

    void Update()
    {
        ChangeScene();
        mCurrentScene.SceneUpdate();
    }

    /// <summary>
    /// 让mCurrentScene和当前场景保持一致
    /// </summary>
    private void ChangeScene()
    {      
        if (mCurrentScene.GetType().Name != SceneManager.GetActiveScene().name)
        {
            //Debug.Log($"Scene have changed to:{SceneManager.GetActiveScene().name}");
            mCurrentScene = FindObjectOfType<IGameScene>();
            mCurrentScene.Init();
        }
    }
}
