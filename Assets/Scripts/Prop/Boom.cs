﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : IProp
{
    public override void PropFuction(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.DeleteBody(player.GetBodyLength() / 2);
        Destroy(this.gameObject);
    }
}
