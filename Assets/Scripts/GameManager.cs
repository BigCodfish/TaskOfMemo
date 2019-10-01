using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private IGameScene mCurrentScene;

    void Start()
    {
        mCurrentScene = FindObjectOfType<IGameScene>();
        DontDestroyOnLoad(this.gameObject);
        mCurrentScene.Init();
    }

    void Update()
    {
        ChangeScene();
    }

    /// <summary>
    /// 让mCurrentScene和当前场景保持一致
    /// </summary>
    private void ChangeScene()
    {
        if (mCurrentScene.name != SceneManager.GetActiveScene().name)
            mCurrentScene = FindObjectOfType<IGameScene>();
    }
}
