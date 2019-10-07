using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScene : IGameScene
{
    private Player mPlayer;
    private int[] mEndScore;
    private List<GameObject> mColorCubes;
    private float timer, startTime;

    public override void Init()
    {
        uISystem = new UISystem();
        recorder = new Recorder();
        mColorCubes = new List<GameObject>();

        mPlayer = FindObjectOfType<Player>();

        recorder.datas.Add("Distance", 0);

        mPlayer.InitColorSnake();
        uISystem.UISwitchButton("ColorModeUI");

        haveEnd = false;
        haveStop = false;

        startTime = Time.time;
    }
    public override void SceneUpdate()
    {
        if (haveEnd)
        {
            uISystem.UIHideButton("ColorModeUI");
            uISystem.UISwitchButton("EndUI");
            mPlayer.StopRigid();
            if (recorder.datas.ContainsKey("Distance")) mEndScore = new int[] { recorder.datas["Distance"] };
            uISystem.DataText(mEndScore);
            haveStop = true;
            //haveEnd = false;
        }
        if (!haveStop)
        {
            mPlayer.HorizontalMove();
            //UI上的数据
            AddDistance();
            int[] tempDatas = recorder.GetDatas();
            uISystem.DataText(tempDatas);
        }
    }
    public override void Exit()
    {
        mPlayer.transform.position = new Vector2(-5, 0);
        mPlayer.DeleteSnake();
        //uISystem.DeleteUIDictionary();
        DeleteList();
        recorder.DeleteDictionary();
    }

    public override void RePlay()
    {
        Exit();
        Init();
    }

    public override void SetList(GameObject go)
    {
        mColorCubes.Add(go);
    }

    public override void GameStop(bool value)
    {
        haveStop = value;
        if (value) mPlayer.StopRigid();
        else mPlayer.RecoverRigid();
    }

    private void DeleteList()
    {
        Debug.Log("DeleleList");
        for (int i = 0; i < mColorCubes.Count; i++)
        {
            Destroy(mColorCubes[i]);
        }
    }
    private void AddDistance()
    {
        if(Time.time-startTime>1)
        {
            recorder.ChangeData("Distance", 1);
            startTime = Time.time;
        }
    }
}
