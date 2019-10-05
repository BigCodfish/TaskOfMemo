using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : IProp
{
    public override void PropFuction(Collider2D collision)
    {
        collision.GetComponent<Player>().AddSpeed(1);
        Destroy(this.gameObject);
    }
}
