using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
    private bool reachedEndOfPath = false;

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
    }

    void Update()
    {
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        
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
        // if (player != null)
        // {
        //     float direction = player.position.x > transform.position.x ? 1 : -1;
        //
        //     rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        //
        //     if (animator != null)
        //     {
        //         animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //     }
        //
        //     Vector3 localScale = transform.localScale;
        //     localScale.x = direction > 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
        //     transform.localScale = localScale;
        // }
    }
    
    private void UpdatePath()
    {
        if (player != null)
        {
            Seeker seeker = GetComponent<Seeker>();
            if (seeker.IsDone())
            {
                seeker.StartPath(GetComponent<Rigidbody2D>().position, player.position, OnPathComplete);
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
