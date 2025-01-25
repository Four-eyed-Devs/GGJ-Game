using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int spawnedEnemies = 0;
    public int numberOfEnemiesToSpawn = 3;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnDelay = 3f;
    public Transform player;
    public float spawnRadius = 20f;

    private float nextSpawnTime;

    void Update()
    {
        // Calculate 2D distance
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);
        Debug.Log($"Time: {Time.time}, Next Spawn: {nextSpawnTime}, Distance: {distanceToPlayer}");

        if (Time.time > nextSpawnTime && distanceToPlayer <= spawnRadius)
        {
            Debug.Log("Player is within range. Spawning enemy...");
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void SpawnEnemy()
    {
        Debug.Log($"Trying to spawn enemy. Spawned: {spawnedEnemies}/{numberOfEnemiesToSpawn}");
        if (numberOfEnemiesToSpawn > spawnedEnemies)
        {
            Debug.Log("SPAWNED ENEMY!");
            spawnedEnemies++;
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}