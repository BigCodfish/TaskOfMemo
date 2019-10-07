using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class NumberFood : MonoBehaviour
{
    private int mNumber;
    public Text mtext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioSystem>().PlayPropAudio(2);
            collision.GetComponent<Player>().AddBody(mNumber);
            this.gameObject.SetActive(false);
        }
    }

    public void SetNumber(int number)
    {
        mNumber = number;
        mtext.text = Convert.ToString(mNumber);
    }
}
