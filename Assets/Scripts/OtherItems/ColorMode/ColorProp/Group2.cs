using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group2 : IColorProp
{
    public GameObject[] part1;
    public GameObject[] part2;
    public GameObject[] part3;
    protected override void GroupInit()
    {
        int id = (int)Random.Range(1, 2.99f);
        for (int i = 0; i < part1.Length; i++)
        {
            part1[i].GetComponent<SpriteRenderer>().color = colors[id];
        }
        for (int i = 0; i < part2.Length; i++)
        {
            part2[i].GetComponent<SpriteRenderer>().color = colors[id + 1];
        }
        for (int i = 0; i < part3.Length; i++)
        {
            part3[i].GetComponent<SpriteRenderer>().color = colors[id - 1];
        }
    }
}
