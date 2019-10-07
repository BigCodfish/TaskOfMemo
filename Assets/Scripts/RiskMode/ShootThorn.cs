using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootThorn : MonoBehaviour
{
    public GameObject thorn;
    private float timer;
    public float time;
    private void Start()
    {
        timer = Time.time;
    }

    private void Update()
    {
        if(Time.time-timer>time)
        {
            Instantiate(thorn, transform);
        }
    }

}
