using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D;
using UnityEngine;

public class FlyTrash : Trash
{
    public float moveRadius; // ������, � �������� �������� ���� ����� ������ �����
    public float checkDistance; // ����������� ���������� �� ���� ��� ����� �����
    public LayerMask obstacleLayer; // ���� ����������� ��� �������� ������������
    public float movementSpeed; // �������� ����������� �����
    public Sprite dead;

    private Vector3 targetPoint;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        FindNewTargetPoint();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    private void FindNewTargetPoint()
    {
        bool pointFound = false;

        while (!pointFound)
        {
            // ��������� ����� � �������� ������� (������ � 3D)
            Vector3 randomDirection = Random.insideUnitCircle * moveRadius; // ���������� Random.insideUnitCircle ��� 2D-���������
            randomDirection += transform.position;
            randomDirection.z = transform.position.z; // ������������� Z-���������� ������� ����� ������ Z-���������� �������

            // �������� �� �����������
            if (!Physics.Raycast(transform.position, randomDirection - transform.position, moveRadius, obstacleLayer))
            {
                Debug.DrawRay(transform.position,randomDirection - transform.position * moveRadius);

                targetPoint = randomDirection;
                pointFound = true;
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // ����������� ����� � ������� �����
        if (movementSpeed > 0) // ���������, ����� �� �� ���������
        {
            Vector3 direction = (targetPoint - transform.position).normalized;
            direction.z = 0; // �������� Z-��������� ������� �����������
            rigidbody.velocity = direction * movementSpeed; // ���������� rigidbody.velocity ��� �������� ��������

            // �������� �� ���������� ����
            if (Vector3.Distance(transform.position, targetPoint) < checkDistance)
            {
                FindNewTargetPoint(); // ����� ����
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            rigidbody.gravityScale = 2;
            movementSpeed = 0; // ������������� ��������, �� �� ������� ������
            spriteRenderer.sprite = dead; // ���������� spriteRenderer ��� ��������� �������
            moveRadius = 0f;
            rigidbody.mass = 0.5f;
        }
    }
}