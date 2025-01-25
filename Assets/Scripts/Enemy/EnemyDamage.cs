using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float damageInterval;

    public PlayerHealth playerHealth;
    private float lastDamageTime;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            }

            if (playerHealth != null && Time.time >= lastDamageTime + damageInterval)
            {
                playerHealth.TakeDamage(damage);
                lastDamageTime = Time.time;
            }

        }
    }
}
