using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private IGameScene mCurrentScene;

    void Awake()
    {
        mCurrentScene = FindObjectOfType<IGameScene>();
        mCurrentScene.Init();
        DontDestroyOnLoad(this.gameObject);        
    }

    void Update()
    {
        ChangeScene();
        ReLoadScene();
        mCurrentScene.SceneUpdate();
    }

    /// <summary>
    /// 让mCurrentScene和当前场景保持一致
    /// </summary>
    private void ChangeScene()
    {      
        if (mCurrentScene.GetType().Name != SceneManager.GetActiveScene().name)
        {
            Debug.Log($"Scene have changed to:{SceneManager.GetActiveScene().name}");
            mCurrentScene = FindObjectOfType<IGameScene>();
            mCurrentScene.Init();
        }
    }
    private void ReLoadScene()
    {
        if(FindObjectOfType<IGameScene>().reStart)
        {
            mCurrentScene = FindObjectOfType<IGameScene>();
            mCurrentScene.Init();
        }
    }
}
