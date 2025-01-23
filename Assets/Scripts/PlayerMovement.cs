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

    //ksdjfbasdhbfsdbfhfsdfjbsdfksdfjbjfbsdkjfbsdkhjbfshjdsbf AAAAAAAAAAAAAAAAAAAAa

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        Vector3 spawnBubblePos = new Vector3(transform.position.x, transform.position.y - 1.7f, transform.position.z);

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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }
}
