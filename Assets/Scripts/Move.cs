using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb;
    public float MoveX;
    public float MoveY;
    public float speed = 2.0f;
    public float jumpForse = 2.0f;
    void Start()
    {
        Physics2D.gravity = new Vector2(0, -9.6f);
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(MoveX, MoveY) * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}
