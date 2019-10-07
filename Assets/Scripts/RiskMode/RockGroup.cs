using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGroup : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Destroy(door);
            Destroy(this.gameObject);
        }
    }
}
