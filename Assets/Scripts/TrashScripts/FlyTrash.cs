using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrash : MonoBehaviour
{
    new private Rigidbody2D rigidbody;
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
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
