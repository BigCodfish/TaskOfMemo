using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThorn : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 20);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 1.5f,Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            FindObjectOfType<AudioSystem>().PlayPropAudio(7);
            Player player = collision.gameObject.GetComponent<Player>();
            player.DeleteBody(player.GetBodyLength() / 2);
        }
    }
}
