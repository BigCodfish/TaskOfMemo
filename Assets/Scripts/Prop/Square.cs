using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Square : MonoBehaviour
{
    private int mNumber;
    public Text mtext;
    public SpriteRenderer mImage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().DeleteBody(mNumber);
            this.gameObject.SetActive(false);
        }
    }

    public void SetSquare(int number,Sprite image)
    {
        mNumber = number;
        mtext.text = Convert.ToString(mNumber);
        mImage.sprite = image;
    }
}
