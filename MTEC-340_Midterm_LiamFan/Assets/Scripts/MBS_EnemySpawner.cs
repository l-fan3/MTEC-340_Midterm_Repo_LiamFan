using UnityEngine;

public class MBS_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Vector3 leftSpawnPoint = new Vector3(-9, -3, 0);  // Left spawn position
    public Vector3 rightSpawnPoint = new Vector3(9, -3, 0);  // Right spawn position
    public float spawnRate = 2.0f;  // Time between spawns

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnRate);
    }

    void SpawnEnemy()
    {
        // Randomly choose between left and right spawn position
        Vector3 spawnPosition = (Random.value < 0.5f) ? leftSpawnPoint : rightSpawnPoint;

        // Spawn the enemy at the selected position
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Flip enemy if spawned on the right to face left
        if (spawnPosition == rightSpawnPoint)
        {
            enemy.transform.localScale = new Vector3(-1, 1, 1);  // Flip horizontally
        }
    }
}