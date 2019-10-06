using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrigger : MonoBehaviour
{
    public GameObject[] targetObjects;
    public float[] offsets;
    private IGameScene currentScene;

    private void Start()
    {
        currentScene = FindObjectOfType<IGameScene>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            for (int i = 0; i < targetObjects.Length; i++)
            {
                GameObject go = Instantiate(targetObjects[i], new Vector2(transform.position.x + offsets[i], transform.position.y), Quaternion.identity);
                currentScene.SetList(go);
            }
            
        }
    }
}
