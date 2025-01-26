using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField]
    private int countToNextLevel;

    [SerializeField]
    private GameObject doorPrefab; // Assign your door prefab in the Inspector

    [SerializeField]
    private Transform doorSpawnPoint; // Optional: Assign the door's spawn location in the Inspector
    
    private bool doorSpawned = false;
    public int defeatCount;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyDefeated()
    {
        defeatCount++;

        if (defeatCount == countToNextLevel && !doorSpawned)
        {
            SpawnDoor();
        }
    }

    private void SpawnDoor()
    {
        if (doorSpawnPoint != null)
        {
            Instantiate(doorPrefab, doorSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            // Default to the center of the room if no spawn point is set
            Instantiate(doorPrefab, Vector3.zero, Quaternion.identity);
        }

        doorSpawned = true;
    }
}
