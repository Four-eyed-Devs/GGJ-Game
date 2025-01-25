using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


[RequireComponent(typeof(Seeker))]
public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Transform enemyGFX;

    private Rigidbody2D rb;
    private Animator animator;
    
    
    // Pathfinding stuff
    private Seeker seeker;
    public float speed = 200f;
    private Path path;
    public float nextWaypointDistance = 3f;
    private int currentWaypoint = 0;
    //private bool reachedEndOfPath = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        InvokeRepeating("UpdatePath", 0f, 0.25f);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyGFX = transform;
    }

    void Update()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            //reachedEndOfPath = true;
            return;
        }
        
        //reachedEndOfPath = false;
        
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed *Time.deltaTime;
        
        rb.AddForce(force);
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f) 
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void FixedUpdate()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            //reachedEndOfPath = true;
            rb.velocity = Vector2.zero; // Stop movement
            return;
        }

        //reachedEndOfPath = false;

        // Movement logic
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 velocity = direction * speed * Time.fixedDeltaTime;
        rb.velocity = velocity;

        // Check if we've reached the next waypoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        // Flip the sprite based on movement direction
        if (velocity.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (velocity.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void UpdatePath()
    {
         if (player != null)
         {
             float distanceToPlayer = Vector2.Distance(rb.position, player.position);
                if (distanceToPlayer < 20f)
                {
                     if (seeker.IsDone())
                     {
                         seeker.StartPath(rb.position, player.position, OnPathComplete);
                     }
                }
         }
    }
    
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
