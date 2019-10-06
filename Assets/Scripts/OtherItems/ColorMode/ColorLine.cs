using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLine : MonoBehaviour
{
    private Color[] mColors = new Color[4];
    private float timer;
    private float startTime;
    public Color currentColor;
    private SpriteRenderer sr;

    private void Start()
    {
        startTime = Time.time;
        sr = GetComponent<SpriteRenderer>();
        ColorUtility.TryParseHtmlString("#ffc1ac", out mColors[0]);
        ColorUtility.TryParseHtmlString("#c5ffe0", out mColors[1]);
        ColorUtility.TryParseHtmlString("#fffdc8", out mColors[2]);
        ColorUtility.TryParseHtmlString("#acd7ff", out mColors[3]);
        currentColor = mColors[0];
    }
    private void Update()
    {
        sr.color = currentColor;
        timer = Time.time - startTime;
        ChangeColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = currentColor;
    }

    private void ChangeColor()
    {
        if (timer > 1)
        {
            int id = (int)Random.Range(0, 3.99f);
            currentColor = mColors[id];
            startTime = Time.time;
        }
    }
}
