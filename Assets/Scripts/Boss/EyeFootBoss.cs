using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFootBoss : MonoBehaviour
{
    private Transform player; 

    private Animator anim;

    [SerializeField]
    private float attackTimer;

    private bool isFacingLeft = true;
    private bool canFlip = true;
    private bool canAttack = true;

    void Start()
    {
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player != null)
        {
            FlipTowardsPlayer();
        }
    }

    private void FlipTowardsPlayer()
    {
        float directionToPlayer = player.position.x - transform.position.x;

        if(canFlip)
        {
            if (directionToPlayer > 0 && isFacingLeft)
            {
                Flip(0);
            }
            else if (directionToPlayer < 0 && !isFacingLeft)
            {
                Flip(180);
            }
        }
    }

    private void Flip(float yRotation)
    {
        isFacingLeft = !isFacingLeft;

        transform.Rotate(0f, 180, 0f);
    }

    public void LockFlip()
    {
        canFlip = false;    
    }

    public void UnlockFlip()
    {
        canFlip = true;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (canAttack)
            {
                StartCoroutine(StartAttack());
            }
        }
    }

    public void SetIdle()
    {
        anim.SetBool("isAttacking", false);
        anim.SetBool("isIdle", true);
    }

    public void SetAttack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isIdle", false);
    }

    private IEnumerator StartAttack()
    {
        SetAttack();
        canAttack = false;

        yield return new WaitForSeconds(attackTimer);

        canAttack = true;
    }
}
