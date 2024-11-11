using UnityEngine;

public class SpawnRandomObject : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ������ � ��������� �������� ��� ������

    public float spawnInterval = 2f; // �������� ����� ��������
    public int maxLayerTrashCount = 10; // ������������ ���������� �������� ���� "LayerTrash"
    public int maxFlyTrashCount = 15; // ������������ ���������� �������� ���� "FlyTrash"
    public int maxRunTrashCount = 8; // ������������ ���������� �������� ���� "RunTrash"

    public GameObject layerTrash; // ������ ������� "LayerTrash"
    public GameObject flyTrash; // ������ ������� "FlyTrash"
    public GameObject runTrash; // ������ ������� "RunTrash"

    private float lastSpawnTime;

    void Update()
    {
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject objectToSpawn = objectsToSpawn[randomIndex];

            // ��������� ������ ������ ��� ������� ����
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
        // ���������� GameObject.FindObjectsOfType ��� ������ ���� �������� �� �����
        GameObject[] foundObjects = GameObject.FindObjectsOfType<GameObject>();

        int count = 0;

        // ���������� ��������� �������
        foreach (GameObject obj in foundObjects)
        {
            // ���������, �������� �� ������ ����������� ����������� �������
            if (obj.name == prefab.name)
            {
                count++;
            }
        }
        return count;
    }
}