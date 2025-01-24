using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject bubble;

    private Rigidbody2D rb;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private float
        speed,
        jumpForce,
        groundCheckRadius;

    private bool isGrounded;
    private bool bubbled;
    public Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public float bubblePos = -1.7f;
    private void Update()
    {
        Vector3 spawnBubblePos = new Vector3(transform.position.x, transform.position.y + bubblePos, transform.position.z);

        CheckGround();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpForce);
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && !bubbled)
        {
            Instantiate(bubble, spawnBubblePos, Quaternion.identity);
            bubbled = true;
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (isGrounded)
        {
            //animator.SetBool("isJumping", false);
            bubbled = false;
        }
    }

    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
    }

    public void Jump(float jumpForce)
    {
        //animator.SetBool("isJumping", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
