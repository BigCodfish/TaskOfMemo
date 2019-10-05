using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : IProp
{
    public override void PropFuction(Collider2D collision)
    {
        collision.GetComponent<Player>().AddBody(1);
        //调用音乐和分数系统
        Destroy(this.gameObject);
    }
}
