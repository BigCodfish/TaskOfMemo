using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    public Dictionary<string, int> datas = new Dictionary<string, int>();
    public void ChangeData(string name, int value) => datas[name] += value;
    public int[] GetDatas()
    {
        int[] temp = new int[3];
        int i = 0;
        foreach (int value in datas.Values)
        {
            temp[i] = value;
            i++;
        }
        return temp;
    }
}
