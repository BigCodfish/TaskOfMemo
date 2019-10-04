using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : IGameScene
{
    private ItemCreateSystem createSystem;
    private Player player;

    public override void Init()
    {
        createSystem = FindObjectOfType<ItemCreateSystem>();
        player = FindObjectOfType<Player>();
        uISystem = new UISystem();
        createSystem.InitWall();
        createSystem.InitFood();
        createSystem.InitProp();
    }
    public override void SceneUpdate()
    {
        player.FreeMove();
        createSystem.KeepFoodCount();
        createSystem.KeepPropCount();
    }
}
