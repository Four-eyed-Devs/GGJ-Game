using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject bubble;

    private Rigidbody2D rb;
    private Animator animator;

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
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("hasBubbleJumped", bubbled);

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

        if (isGrounded)
        {
            if (inputX != 0)
            {
                animator.SetBool("isIdle", false);
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isIdle", true);
                animator.SetBool("isMoving", false);
            }
        }

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        Flip(inputX);
    }

    private void Flip(float xInput)
    {
        if (xInput > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (xInput < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
    }

    public void Jump(float jumpForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        SetJumpAnim();
    }

    public void GetAttackAnimIn()
    {
        animator.SetBool("isAttacking", true);
        animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", false);
    }

    public void GetAttackAnimOut()
    {
        animator.SetBool("isAttacking", false);
    }

    private void SetJumpAnim()
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isMoving", false);
    }


    public void RestartJumpLoop()
    {
        animator.Play("Jump", 0, 0.3f);
    }

    public void RestartBubbleJumpLoop()
    {
        animator.Play("BubbleJump", 0, 0.4f);
    } 

    public void SetHasBubbleJumped()
    {
        animator.SetBool("hasBubbleJumped", bubbled);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
