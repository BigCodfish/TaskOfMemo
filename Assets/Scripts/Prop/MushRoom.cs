﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom : IProp
{
    public override void PropFuction(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        FindObjectOfType<AudioSystem>().PlayPropAudio(2);
        player.AddBody(player.GetBodyLength() / 2);
        Destroy(this.gameObject);
    }
}
