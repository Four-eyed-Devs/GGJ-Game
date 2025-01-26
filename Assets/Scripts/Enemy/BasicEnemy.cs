using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{  
    [SerializeField]
    protected float health;

    public float maxHealth;

    [SerializeField]
    protected float damageTimer;

    public HealthBarBehaivour HealthBar;

    [SerializeField]
    private GameObject hitEffect;

    protected bool canTakeDamageFromBubble;
    void Start()
    {
        canTakeDamageFromBubble = true;
        HealthBar.SetHealth(health, maxHealth);
    }

    public void TakeDamageFromBubble(float amount)
    {
        if (canTakeDamageFromBubble)
        {
            health -= amount;
            canTakeDamageFromBubble = false;
            HealthBar.SetHealth(health, maxHealth);

            StartCoroutine(ResetDamageTimer());

            if (hitEffect != null)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }

            if (health <= 0)
            {
                OnKill();
            }    
        }
    }

    private void OnKill()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            GameManager.Instance.EnemyDefeated();
            Destroy(gameObject);
        }
    }

    private IEnumerator ResetDamageTimer()
    {
        Debug.Log("Coroutine Started");

        yield return new WaitForSeconds(damageTimer);

        canTakeDamageFromBubble = true;
    }
}
