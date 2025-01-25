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
        if (Time.time > nextSpawnTime && Vector3.Distance(player.position, transform.position) <= spawnRadius)
        {
            Debug.Log("Should SPAWN!");
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