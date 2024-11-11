using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D;
using UnityEngine;

public class FlyTrash : Trash
{
    public float moveRadius; // Радиус, в пределах которого враг будет искать точки
    public float checkDistance; // Минимальное расстояние от цели для смены точки
    public LayerMask obstacleLayer; // Слой препятствий для проверки столкновений
    public float movementSpeed; // Скорость перемещения врага
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
            // Случайная точка в пределах радиуса (теперь в 3D)
            Vector3 randomDirection = Random.insideUnitCircle * moveRadius; // Используем Random.insideUnitCircle для 2D-плоскости
            randomDirection += transform.position;
            randomDirection.z = transform.position.z; // Устанавливаем Z-координату целевой точки равной Z-координате объекта

            // Проверка на препятствия
            if (!Physics.Raycast(transform.position, randomDirection - transform.position, moveRadius, obstacleLayer))
            {
                targetPoint = randomDirection;
                pointFound = true;
            }
        }
    }

    private void MoveTowardsTarget()
    {
        // Перемещение врага к целевой точке
        if (movementSpeed > 0) // Проверяем, можем ли мы двигаться
        {
            Vector3 direction = (targetPoint - transform.position).normalized;
            direction.z = 0; // Обнуляем Z-компонент вектора направления
            rigidbody.velocity = direction * movementSpeed; // Используем rigidbody.velocity для плавного движения

            // Проверка на достижение цели
            if (Vector3.Distance(transform.position, targetPoint) < checkDistance)
            {
                FindNewTargetPoint(); // Смена цели
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            rigidbody.gravityScale = 2;
            movementSpeed = 0; // Останавливаем движение, но не удаляем физику
            spriteRenderer.sprite = dead; // Используем spriteRenderer для изменения спрайта
            moveRadius = 0f;
            rigidbody.mass = 0.5f;
        }
    }
}