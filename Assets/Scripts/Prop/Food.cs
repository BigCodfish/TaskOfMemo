using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : IProp
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") collision.GetComponent<Player>().AddBody(1);
    }
}
