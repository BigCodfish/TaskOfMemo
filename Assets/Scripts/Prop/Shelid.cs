﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelid : IProp
{
    public override void PropFuction(Collider2D collision)
    {
        collision.GetComponent<Player>().SetShield();
        FindObjectOfType<AudioSystem>().PlayPropAudio(4);
        Destroy(this.gameObject);
    }
}
