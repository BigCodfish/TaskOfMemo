using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private float mLength;
    private float mWidth;
    private Vector2 leftBottom;
    private Vector2 rightTop;
    private Collider2D mCollider;
    public bool isHorizontal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") FindObjectOfType<IGameScene>().SetResult(false);
    }
    private void Start()
    {        
        mLength = GetComponent<BoxCollider2D>().size.x;
        mWidth = GetComponent<BoxCollider2D>().size.y;
        if (isHorizontal)
        {
            leftBottom = new Vector2(transform.position.x - mLength / 2 - 0.4f, transform.position.y - mWidth / 2 - 0.4f);
            rightTop = new Vector2(transform.position.x + mLength / 2 + 0.4f, transform.position.y + mWidth / 2 + 0.4f);
        }
        else
        {
            leftBottom = new Vector2(transform.position.x - mWidth / 2 - 0.4f, transform.position.y - mLength / 2 - 0.4f);
            rightTop = new Vector2(transform.position.x + mWidth / 2 + 0.4f, transform.position.y + mLength / 2 + 0.4f);
        }
        
    }
    private void Update()
    {
        Debug.DrawLine(leftBottom, rightTop, Color.red);
        mCollider = Physics2D.OverlapArea(leftBottom, rightTop, ~LayerMask.GetMask("Wall"));
        if(mCollider!=null && mCollider.tag!="Player")
        {
            Destroy(mCollider.gameObject);
            Debug.Log("Destroy Prop");
        }        
    }
}
