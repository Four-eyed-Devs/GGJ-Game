using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    protected float 
        health,
        damageTimer;

    [SerializeField]
    private GameObject hitEffect;

    protected bool canTakeDamageFromBubble;

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamageFromBubble = true;
    }

    public void TakeDamageFromBubble(float amount)
    {
        if (canTakeDamageFromBubble)
        {
            health -= amount;
            canTakeDamageFromBubble = false;

            StartCoroutine(ResetDamageTimer());

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }    
        }
    }

    private IEnumerator ResetDamageTimer()
    {
        Debug.Log("Coroutine Started");

        yield return new WaitForSeconds(damageTimer);

        canTakeDamageFromBubble = true;
    }
}
