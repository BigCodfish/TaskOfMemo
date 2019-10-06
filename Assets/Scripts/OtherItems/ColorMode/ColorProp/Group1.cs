using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group1 : IColorProp
{
    public GameObject[] part1;
    public GameObject[] part2;
    protected override void GroupInit()
    {
        int id = (int)Random.Range(0, 2.99f);
        for (int i = 0; i < part1.Length; i++)
        {
            part1[i].GetComponent<SpriteRenderer>().color = colors[id];
        }
        for (int i = 0; i < part2.Length; i++)
        {
            part2[i].GetComponent<SpriteRenderer>().color = colors[id + 1];
        }
    }
}
