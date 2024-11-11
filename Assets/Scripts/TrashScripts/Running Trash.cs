using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BouncingObject : Trash
{
    bool isFlipped = false;
    public float speed = -1f;
    private float direction = -1;
    public LayerMask NeCritis;
    private Rigidbody2D rigbody;
    Collider2D[] coll = new Collider2D[10];
    public Collider2D collider;
    public ContactFilter2D contactFilter;
    private bool isDead = false; // Флаг, чтобы отслеживать, мертв ли объект
    public Sprite dead;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Flip()
    {
        // Инвертируем флаг и поворачиваем объект на 180 градусов по оси Y
        if (!isDead) // Проверяем, не мертв ли объект
        {
            isFlipped = !isFlipped;
            transform.localScale = new Vector3(isFlipped ? -1 : 1, 1, 1) * Mathf.Abs(transform.localScale.x);
        }
    }


    private void FixedUpdate()
    {
        if (!isDead) // Проверяем, не мертв ли объект
        {
            var jojo = Physics2D.OverlapCollider(collider, contactFilter, coll);
            rigbody.velocity = new Vector2(direction * speed, rigbody.velocity.y);
            bool flipped = rigbody.velocity.x < 0;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * direction, 1.0f, NeCritis);
            Debug.DrawRay(transform.position, transform.right * 1f * direction);

            if (hit.collider != null || jojo != 1)
            {
                direction = -direction;
                Flip();
                Debug.Log(jojo);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            rigbody.gravityScale = 2;
            speed = 0; // ������������� ��������, �� �� ������� ������
            spriteRenderer.sprite = dead; // ���������� spriteRenderer ��� ��������� �������
            rigbody.mass = 0.5f;
        }
    }
}