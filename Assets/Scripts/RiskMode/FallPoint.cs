using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPoint : MonoBehaviour
{
    public GameObject fallThorn;
    private float timer;

    private void Start()
    {
        timer = Time.time;
    }
    private void Update()
    {
        if(Time.time-timer > Random.Range(4,6f))
        {
            timer = Time.time;
            Instantiate(fallThorn, transform.position, fallThorn.transform.rotation);
        }
    }

}
