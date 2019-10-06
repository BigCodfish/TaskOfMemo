using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IColorProp : MonoBehaviour
{
    protected Color[] colors = new Color[4];
    protected virtual void GroupUpdate() { }
    protected virtual void GroupInit() { }

    private void Start()
    {
        ColorUtility.TryParseHtmlString("#ffc1ac", out colors[0]);
        ColorUtility.TryParseHtmlString("#c5ffe0", out colors[1]);
        ColorUtility.TryParseHtmlString("#fffdc8", out colors[2]);
        ColorUtility.TryParseHtmlString("#acd7ff", out colors[3]);
        GroupInit();
    }
    private void Update()
    {
        GroupUpdate();
    }

}
