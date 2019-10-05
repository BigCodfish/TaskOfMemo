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
        createSystem = FindObjectOfType<ItemCreateSystem>();
        player = FindObjectOfType<Player>();
        uISystem = new UISystem();
        createSystem.InitWall();
        createSystem.InitFood();
        createSystem.InitProp();
        createSystem.JudgeItemOverlap();
        player.InitSnake();
        uISystem.UISwitchButton("SimpleModeUI");
    }
    public override void SceneUpdate()
    {
        if(!haveStop) player.FreeMove();
        createSystem.KeepFoodCount();
        createSystem.KeepPropCount();
                
    }

    public void GameStop()
    {
        haveStop = true;
    }
}
