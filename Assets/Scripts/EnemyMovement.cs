using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;

    public float speed;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            float direction = target.position.x > transform.position.x ? 1 : -1;

            rb.velocity = new Vector2(direction * speed, rb.velocity.y);

            if (animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            }

            Vector3 localScale = transform.localScale;
            localScale.x = direction > 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
}
