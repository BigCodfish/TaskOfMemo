using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IProp : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    private bool judgeOverlap = true;
    public virtual void PropFuction(Collider2D collision) { }

    private void AvoidOverlap()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, circleCollider.radius,~LayerMask.GetMask("Wall"));
        if(collider!=null && collider.tag!="Player" && collider != circleCollider)
        {
            Destroy(collider.gameObject);
            Debug.Log("Destroy Overlap Prop");
        }
    }

    public void StartJudgement() => judgeOverlap = true;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PropFuction(collision);
        }
    }

    private void Update()
    {
        if (judgeOverlap)
        {
            AvoidOverlap();
            judgeOverlap = false;
        }
    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.DrawSphere(transform.position, circleCollider.radius);
//    }
}
