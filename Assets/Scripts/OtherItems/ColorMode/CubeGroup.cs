using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGroup : MonoBehaviour
{
    public GameObject[] colorProps;

    private void Start()
    {
        Init().transform.position = transform.position;
        Init().transform.position = new Vector2(transform.position.x+20,transform.position.y);

    }

    private GameObject Init()
    {
        int id = (int)Random.Range(0, 4.99f);
        GameObject go = Instantiate(colorProps[id],transform);
        return go;
    }
}
