using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IProp : MonoBehaviour
{
    private CircleCollider2D circleCollider;

    public virtual void PropFuction() { }

    private void AvoidOverlap()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, circleCollider.radius,~LayerMask.GetMask("Wall"));
        if(collider!=null && collider.tag!="Player" && collider != circleCollider)
        {
            Destroy(collider.gameObject);
            Debug.Log("Destroy Overlap Prop");
        }
    }

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        AvoidOverlap();
    }

//    private void OnDrawGizmos()
//    {
//        Gizmos.DrawSphere(transform.position, circleCollider.radius);
//    }
}
