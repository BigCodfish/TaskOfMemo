using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group4 : IColorProp
{
    public GameObject[] part1;
    public GameObject[] part2;
    public GameObject[] part3;
    protected override void GroupInit()
    {
        int id = (int)Random.Range(0, 3.99f);
        for (int i = 0; i < part1.Length; i++)
        {
            part1[i].GetComponent<SpriteRenderer>().color = colors[id];
            part1[i].GetComponent<ColorCube>().mColor = colors[id];
        }
        for (int i = 0; i < part2.Length; i++)
        {
            part2[i].GetComponent<SpriteRenderer>().color = colors[(id + 1) % 4];
            part2[i].GetComponent<ColorCube>().mColor = colors[(id + 1) % 4];
        }
        for (int i = 0; i < part3.Length; i++)
        {
            part3[i].GetComponent<SpriteRenderer>().color = colors[(id + 2) % 4];
            part3[i].GetComponent<ColorCube>().mColor = colors[(id + 2) % 4];
        }
    }

    protected override void GroupUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).Rotate(Vector3.forward*0.5f, Space.World);
        }
    }
}
