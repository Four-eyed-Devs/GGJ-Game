using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    private BoxCollider2D spawnArea; 

    public GameObject objectToSpawn;

    public float spawnInterval;

    void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();

        StartCoroutine(SpawnObjectsCoroutine());
    }

    IEnumerator SpawnObjectsCoroutine()
    {
        while (true) 
        {
            Vector3 randomPosition = GetRandomPositionInCollider();
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            SetSpawnInterval();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SetSpawnInterval()
    {
        spawnInterval = Random.Range(0.5f, 3f);
    }

    private Vector3 GetRandomPositionInCollider()
    {
        Bounds bounds = spawnArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        Vector2 randomPosition = new Vector2(x, y);

        if (spawnArea.ClosestPoint(randomPosition) != randomPosition)
        {
            randomPosition = spawnArea.ClosestPoint(randomPosition);
        }

        return randomPosition;
    }
}
