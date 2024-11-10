using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrash : Trash
{
    private float speed = 3f;
    new private Rigidbody2D rigidbody;
    Vector2 RandomMovement;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            rigidbody.gravityScale = 1;
            speed = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float r1 = Random.Range(-1f, 3f);
        float r2 = Random.Range(-1f, 3f);
        RandomMovement.x = r1 * speed;
        RandomMovement.y = r2 * speed;


    }
}
