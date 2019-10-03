using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Vector2 mMoveDir;
    private float vertical;
    private float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mMoveDir = new Vector2(horizontal, vertical).normalized;
        GetComponent<Rigidbody2D>().MovePosition(mMoveDir);
    }
}
