using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTrash : Trash
{
   /* ////    public float speed = 3f;
    ////    new private Rigidbody2D rigidbody;
    ////    public float checkRadius = 0.5f; // Радиус проверки столкновений
    ////    public LayerMask obstacleLayer; // Слой, на котором находятся препятствия
    //   private Vector2 direction;

    //    // Start is called before the first frame update
    //    void Start()
    //    {
    //        rigidbody = GetComponent<Rigidbody2D>();
    //        SetRandomDirection();
    //    }
    //    private void OnCollisionEnter2D(Collision2D collision)
    //    {
    //        if (collision.gameObject.GetComponent<metla>())
    //        {
    //            rigidbody.gravityScale = 1;
    //            speed = 0;
    //        }
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {
    //        if (Physics2D.OverlapCircle(transform.position, checkRadius, obstacleLayer))
    //        {
    //            // Если есть столкновение, выбираем новое случайное направление
    //            SetRandomDirection();
    //        }
    //        transform.Translate(direction * speed * Time.deltaTime);
    //    }
    //    private void SetRandomDirection()
    //    {
    //        // Генерация случайных чисел от -1 до 1
    //        float x = Random.Range(-1f, 1f);
    //        float y = Random.Range(-1f, 1f);

    //        // Нормализация вектора (чтобы длина была равна 1)
    //        direction = new Vector2(x, y).normalized;
    //    }*/
    public float moveRadius = 10f; // Радиус, в пределах которого враг будет искать точки
    public float checkDistance = 1f; // Минимальное расстояние от цели для смены точки
    public LayerMask obstacleLayer; // Слой препятствий для проверки столкновений
    public float movementSpeed = 3f; // Скорость перемещения врага

    private Vector3 targetPoint;
    new private Rigidbody2D rigidbody;

    void Start()
    {
        FindNewTargetPoint();
        rigidbody = GetComponent<Rigidbody2D>();
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
            // Случайная точка в пределах радиуса
            Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
            randomDirection += transform.position;
            randomDirection.y = transform.position.y; // Учитываем только горизонтальную плоскость

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
        Vector3 direction = (targetPoint - transform.position).normalized;
        transform.position += direction * movementSpeed * Time.deltaTime;

        // Проверка на достижение цели
        if (Vector3.Distance(transform.position, targetPoint) < checkDistance)
        {
            FindNewTargetPoint(); // Смена цели
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<metla>())
        {
            rigidbody.gravityScale = 1;
            movementSpeed = 0;
        }
    }
}
