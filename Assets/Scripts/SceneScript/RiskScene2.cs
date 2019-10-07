using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiskScene2 : IGameScene
{
    private Player mPlayer;
    private int[] mEndScore;
    public GameObject foodGroup;
    public Transform[] foodPoints;

    private List<GameObject> mPropGroups;

    public override void Init()
    {
        uISystem = new UISystem();
        recorder = new Recorder();
        mPropGroups = new List<GameObject>();
        mPlayer = FindObjectOfType<Player>();

        recorder.datas.Add("SnakeLength", 5);
        recorder.datas.Add("Score", 0);

        InitItems();
        mPlayer.InitSnake(4);
        uISystem.UISwitchButton("RiskModeUI");

        haveEnd = false;
        haveStop = false;
    }

    public override void SceneUpdate()
    {
        if (!haveEnd && mPlayer.GetBodyLength() <= 1)
        {
            SetResult(false);
        }
        if (haveEnd && !gameResult)
        {
            mPlayer.StopRigid();
            uISystem.UIHideButton("RiskModeUI");
            uISystem.UISwitchButton("EndUI");
            if (recorder.datas.ContainsKey("Score")) mEndScore = new int[] { recorder.datas["Score"] };
            uISystem.DataText(mEndScore);
            haveStop = true;
            //haveEnd = false;
        }
        else if (haveEnd && gameResult)
        {
            mPlayer.StopRigid();
            uISystem.UIHideButton("RiskModeUI");
            uISystem.UISwitchButton("SuccessUI");
            if (recorder.datas.ContainsKey("Score")) mEndScore = new int[] { recorder.datas["Score"] };
            uISystem.DataText(mEndScore);
            haveStop = true;
        }
        if (!haveStop)
        {
            mPlayer.FreeMove2();
            //UI上的数据
            int[] tempDatas = recorder.GetDatas();
            uISystem.DataText(tempDatas);
        }
    }

    public override void Exit()
    {
        mPlayer.transform.position = new Vector2(-6, 1);
        mPlayer.DeleteSnake();
        recorder.DeleteDictionary();
        DeleteList();
    }

    public override void RePlay()
    {
        Exit();
        Init();
    }

    private void InitItems()
    {
        for (int i = 0; i < foodPoints.Length; i++)
        {
            mPropGroups.Add(Instantiate(foodGroup, foodPoints[i].position, Quaternion.identity));
        }
    }

    public override void GameStop(bool value)
    {
        haveStop = value;
        if (value) mPlayer.StopRigid();
        else mPlayer.RecoverRigid();
    }

    private void DeleteList()
    {
        for (int i = 0; i < mPropGroups.Count; i++)
        {
            Destroy(mPropGroups[i]);
        }
    }
}
