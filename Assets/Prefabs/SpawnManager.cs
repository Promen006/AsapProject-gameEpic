using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    

    [Header("Настройки спавна")]
    public List<Transform> groundSpawnPoints;  // Координаты для наземного мусора
    public List<Transform> airSpawnPoints;     // Координаты для воздушного мусора
    public List<GameObject> trashPrefabs;   // Список префабов мусора

    [Header("Настройки таймера")]
    public float minSpawnTime = 1.0f;        // Минимальное время до спавна
    public float maxSpawnTime = 5.0f;        // Максимальное время до спавна

    private void Start()
    {
        StartCoroutine(SpawnTrashRoutine());
    }

    // Корутина для спавна мусора через случайные промежутки времени
    private IEnumerator SpawnTrashRoutine()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(spawnInterval);
            SpawnTrash();
        }
    }

    // Функция для спавна мусора
    private void SpawnTrash()
    {
        // Выбираем случайный префаб из списка
        var randomTrash = trashPrefabs[Random.Range(0, trashPrefabs.Count)];

        // Определяем спавнпоинт в зависимости от типа мусора
        Vector2 spawnPosition;
        if (randomTrash.GetComponent<Trash>().trashType == Trash.TrashType.Ground)
        {
            spawnPosition = groundSpawnPoints[Random.Range(0, groundSpawnPoints.Count)].position;
        }
        else
        {
            spawnPosition = airSpawnPoints[Random.Range(0, airSpawnPoints.Count)].position;
        }

        // Спавним выбранный префаб на выбранной позиции
        Instantiate(randomTrash, spawnPosition, Quaternion.identity);
    }
}