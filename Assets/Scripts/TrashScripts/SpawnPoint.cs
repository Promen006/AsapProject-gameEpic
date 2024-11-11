using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Массив с префабами объектов для спавна

    public float spawnInterval = 2f; // Интервал между спавнами
    public int maxLayerTrashCount = 10; // Максимальное количество объектов типа "LayerTrash"
    public int maxFlyTrashCount = 15; // Максимальное количество объектов типа "FlyTrash"
    public int maxRunTrashCount = 8; // Максимальное количество объектов типа "RunTrash"

    public GameObject layerTrash; // Префаб объекта "LayerTrash"
    public GameObject flyTrash; // Префаб объекта "FlyTrash"
    public GameObject runTrash; // Префаб объекта "RunTrash"

    private float lastSpawnTime;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];

            // Проверяем только лимиты для каждого типа
            if (objectToSpawn == layerTrash && GetObjectCount(layerTrash) >= maxLayerTrashCount)
            {
                return;
            }
            else if (objectToSpawn == flyTrash && GetObjectCount(flyTrash) >= maxFlyTrashCount)
            {
                return;
            }
            else if (objectToSpawn == runTrash && GetObjectCount(runTrash) >= maxRunTrashCount)
            {
                return;
            }

            Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            lastSpawnTime = Time.time;
        }
    }

    private int GetObjectCount(GameObject prefab)
    {
        // Используем GameObject.FindObjectsOfType для поиска всех объектов на сцене
        GameObject[] foundObjects = GameObject.FindObjectsOfType<GameObject>();

        int count = 0;

        // Перебираем найденные объекты
        foreach (GameObject obj in foundObjects)
        {
            // Проверяем, является ли объект экземпляром переданного префаба
            if (obj.name == prefab.name)
            {
                count++;
            }
        }
        return count;
    }
}