using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScene : IGameScene
{
    private Player mPlayer;
    private int[] mEndScore;
    private List<GameObject> mColorCubes;

    public override void Init()
    {
        uISystem = new UISystem();
        recorder = new Recorder();
        mColorCubes = new List<GameObject>();

        mPlayer = FindObjectOfType<Player>();

        mPlayer.InitColorSnake();
        uISystem.UISwitchButton("ColorModeUI");

        haveEnd = false;
        haveStop = false;
    }
    public override void SceneUpdate()
    {
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
        mColorCubes.Add(go);
    }

    private void DeleteList()
    {
        for (int i = 0; i < mColorCubes.Count; i++)
        {
            Destroy(mColorCubes[i]);
        }
    }
}
