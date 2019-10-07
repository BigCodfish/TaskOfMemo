using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonousGrass : IProp
{
    public override void PropFuction(Collider2D collision)
    {        
        collision.GetComponent<Player>().DeleteBody(2);
        FindObjectOfType<AudioSystem>().PlayPropAudio(6);
        Destroy(this.gameObject);
    }
}
