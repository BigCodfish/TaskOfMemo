using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCube : MonoBehaviour
{
    private Color mColor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&&mColor!=collision.GetComponent<Player>().mcolor)
        {
            FindObjectOfType<IGameScene>().SetResult(false);
        }
    }
}
