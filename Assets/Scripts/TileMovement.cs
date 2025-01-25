using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public float moveDistance = 5f;  // Distance the tile will move in each direction.
    public float moveSpeed = 2f;     // Speed of the tile's movement.

    private Vector3 startPos;       // The starting position of the tile.
    private Vector3 targetPos;      // The target position for the tile to move towards.
    private bool movingRight = true; // Direction of movement.

    void Start()
    {
        // Save the initial position of the tile.
        startPos = transform.position;
        targetPos = startPos + Vector3.right * moveDistance;
    }

    void Update()
    {
        // Move the tile towards the target position.
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Check if the tile has reached the target position.
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            // Reverse direction and update the target position.
            movingRight = !movingRight;
            targetPos = movingRight ? startPos + Vector3.right * moveDistance : startPos;
        }
    }
}
