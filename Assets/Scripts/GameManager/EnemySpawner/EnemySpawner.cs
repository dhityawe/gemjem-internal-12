using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;             // Spawn point for enemies
    public GameObject[] enemyPrefabs;        // Array to hold enemy prefabs
    public float spawnInterval = 2f;         // Time between each spawn
    public int minPrefabQuantity = 1;        // Minimum number of prefabs to spawn
    public int maxPrefabQuantity = 5;        // Maximum number of prefabs to spawn

    private float spawnTimer;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemies();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemies()
    {
        // Randomly determine how many enemies to spawn
        int spawnCount = Random.Range(minPrefabQuantity, maxPrefabQuantity + 1);
        
        for (int i = 0; i < spawnCount; i++)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        }
    }
}
