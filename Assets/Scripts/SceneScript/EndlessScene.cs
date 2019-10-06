using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScene : IGameScene
{
    private Player mPlayer;
    private int[] mEndScore;
    private List<GameObject> mPropGroups;

    public override void Init()
    {
        uISystem = new UISystem();
        recorder = new Recorder();
        mPropGroups = new List<GameObject>();

        mPlayer = FindObjectOfType<Player>();

        recorder.datas.Add("SnakeLength", 5);
        recorder.datas.Add("Score", 0);

        mPlayer.InitSnake(4);
        uISystem.UISwitchButton("EndlessModeUI");

        haveEnd = false;
        haveStop = false;
    }

    public override void SceneUpdate()
    {
        if (!haveEnd && mPlayer.GetBodyLength() <= 1)
        {
            SetResult(false);
        }
        if (haveEnd)
        {
            uISystem.UIHideButton("EndlessModeUI");
            uISystem.UISwitchButton("EndUI");
            if (recorder.datas.ContainsKey("Score")) mEndScore = new int[] { recorder.datas["Score"] };
            uISystem.DataText(mEndScore);
            haveStop = true;
            //haveEnd = false;
        }
        if (!haveStop)
        {
            mPlayer.HorizontalMove();
            //UI上的数据
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
        mPropGroups.Add(go);
    }

    private void DeleteList()
    {
        for (int i = 0; i < mPropGroups.Count; i++)
        {
            Destroy(mPropGroups[i]);
        }
    }
}
