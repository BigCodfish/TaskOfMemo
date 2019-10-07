using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group1 : IColorProp
{
    protected override void GroupInit()
    {
        int id = (int)Random.Range(0, 2.99f);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = colors[(id + i) % 4];
            transform.GetChild(i).GetComponent<ColorCube>().mColor = colors[(id + i) % 4];
        }
        
    }
}
