using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrash : Trash
{
    public float moveRadius; // Radius within which the object can move randomly
    public float checkDistance; // Distance to check if near the target point
    public LayerMask obstacleLayer; // Layer for obstacles to avoid
    public float movementSpeed; // Movement speed of the object
    public Sprite dead; // Sprite to display when the object "dies"

    private Vector3 targetPoint;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private float timeSinceLastChange = 0f; // Timer to track time since last position change
    public float changeInterval = 5f; // Interval to change target position (in seconds)

    void Start()
    {
        FindNewTargetPoint();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveTowardsTarget();

        // Update the timer and check if it's time to change the target position
        timeSinceLastChange += Time.deltaTime;
        if (timeSinceLastChange >= changeInterval)
        {
            FindNewTargetPoint();
            timeSinceLastChange = 0f;
        }
    }

    private void FindNewTargetPoint()
    {
        bool pointFound = false;

        while (!pointFound)
        {
            Vector3 randomDirection = Random.insideUnitCircle * moveRadius;
            randomDirection += transform.position;
            randomDirection.z = transform.position.z;

            if (!Physics.Raycast(transform.position, randomDirection - transform.position, moveRadius, obstacleLayer))
            {
                Debug.DrawRay(transform.position, randomDirection - transform.position * moveRadius);

                targetPoint = randomDirection;
                pointFound = true;
            }
        }
    }

    private void MoveTowardsTarget()
    {
        if (movementSpeed > 0)
        {
            Vector3 direction = (targetPoint - transform.position).normalized;
            direction.z = 0;
            rigidbody.velocity = direction * movementSpeed;

            if (Vector3.Distance(transform.position, targetPoint) < checkDistance)
            {
                FindNewTargetPoint();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            movementSpeed = 0;
            spriteRenderer.sprite = dead;
            moveRadius = 0f;
        }
        else
        {
            FindNewTargetPoint();
        }
    }
}
