using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : IGameScene
{
    private ItemCreateSystem createSystem;
    private Player player;
    private bool haveStop = false;

    public override void Init()
    {
        uISystem = new UISystem();
        recorder = new Recorder();

        recorder.datas.Add("SnakeLength", 5);        
        recorder.datas.Add("Energy", 1);
        recorder.datas.Add("Score", 0);

        createSystem = FindObjectOfType<ItemCreateSystem>();
        player = FindObjectOfType<Player>();
        
        createSystem.InitWall();
        createSystem.InitFood();
        createSystem.InitProp();
        createSystem.JudgeItemOverlap();

        player.InitSnake();
        uISystem.UISwitchButton("SimpleModeUI");
    }
    public override void SceneUpdate()
    {
        if (player.GetBodyLength() <= 1) SetResult(false);
        if (!haveStop)
        {
            player.FreeMove();
            createSystem.KeepFoodCount();
            createSystem.KeepPropCount();
            //UI上的数据
            int[] tempDatas = recorder.GetDatas();
            uISystem.DataText(tempDatas);
        }
        if(haveEnd)
        {
            int[] EndScore = new int[] { recorder.datas["Score"] };
            uISystem.DataText(EndScore);
            haveStop = true;
            uISystem.UIHideButton("SimpleModeUI");
            uISystem.UISwitchButton("EndUI");
        }
        
    }

    public void GameStop()
    {
        haveStop = true;
    }
}
