using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float horizontalOffset = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + horizontalOffset, transform.transform.position.y,transform.position.z);
    }
}
