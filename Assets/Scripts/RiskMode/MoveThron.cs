using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThron : MonoBehaviour
{
    public Transform[] points;
    public int id = 0;
    public float speed;

    private void Update()
    {
        if ((transform.position - points[0].position).magnitude < 0.2f) id = 1;
        else if ((transform.position - points[1].position).magnitude < 0.2f) id = 0;
        transform.Translate((points[id].position - transform.position).normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            FindObjectOfType<AudioSystem>().PlayPropAudio(7);
            Player player = collision.GetComponent<Player>();
            player.DeleteBody(player.GetBodyLength() / 2);
        }
        
    }
}
