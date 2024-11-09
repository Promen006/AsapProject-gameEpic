using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : Trash
{
    public float speed = 1f;
    private float direction = 1;
    public LayerMask NeCritis;
    public Rigidbody2D rigbody;
    private void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigbody.velocity = new Vector2(direction * speed ,rigbody.velocity.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right*direction, 1.0f, NeCritis);
        Debug.DrawRay(transform.position, transform.right * 1f *direction);
        if (hit.collider != null)
        {
            direction = -direction;

        }
    }
}
