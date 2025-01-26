using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject doorPrefab; // Assign the Door Prefab in the Inspector
    public Transform doorSpawnPoint; // Optional: Set spawn location in the Inspector
    private int enemyCount;

    void Start()
    {
        // Count the enemies in the room at the start
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void EnemyDefeated()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            SpawnDoor();
        }
    }

    void SpawnDoor()
    {
        if (doorSpawnPoint != null)
        {
            Instantiate(doorPrefab, doorSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            // Default to the center of the room
            Instantiate(doorPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
