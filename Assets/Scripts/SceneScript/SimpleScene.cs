using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : IGameScene
{
    private ItemCreateSystem createSystem;
    private Player mPlayer;
    private int[] mEndScore;

    public override void Init()
    {
        //Debug.Log("Init SimpleScene");
        
        
        uISystem = new UISystem();
        recorder = new Recorder();

        recorder.datas.Add("SnakeLength", 5);        
        recorder.datas.Add("Energy", 1);
        recorder.datas.Add("Score", 0);

        createSystem = FindObjectOfType<ItemCreateSystem>();
        mPlayer = FindObjectOfType<Player>();
        mPlayer.SetShieldSprite();
        
        createSystem.InitWall();
        createSystem.InitFood();
        createSystem.InitProp();
        createSystem.JudgeItemOverlap();

        mPlayer.InitSnake(4);
        uISystem.UISwitchButton("SimpleModeUI");

        switch (FindObjectOfType<GlobalSetting>().level)
        {
            case 1:
                createSystem.SetCount(60, 70, 60);                
                break;
            case 2:
                createSystem.SetCount(60, 70, 60);
                mPlayer.AddSpeed(1);
                break;
            case 3:
                createSystem.SetCount(60, 90, 40);
                mPlayer.AddSpeed(1);
                break;
            default:
                break;
        }

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
            uISystem.UIHideButton("SimpleModeUI");
            uISystem.UISwitchButton("EndUI");  
            if (recorder.datas.ContainsKey("Score")) mEndScore = new int[] { recorder.datas["Score"] };             
            uISystem.DataText(mEndScore);
            haveStop = true;
            //haveEnd = false;
        }
        if (!haveStop)
        {
            mPlayer.FreeMove();
            createSystem.KeepFoodCount();
            createSystem.KeepPropCount();
            //UI上的数据
            int[] tempDatas = recorder.GetDatas();
            uISystem.DataText(tempDatas);
        }                
    }

    public override void Exit()
    {
        mPlayer.transform.position = Vector2.zero;
        mPlayer.DeleteSnake();
        //uISystem.DeleteUIDictionary();
        createSystem.DeleteItem();
        recorder.DeleteDictionary();    
    }

    public override void RePlay()
    {
        Exit();
        Init();
    }
}
