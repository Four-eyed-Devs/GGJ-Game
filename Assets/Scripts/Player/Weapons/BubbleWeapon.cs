using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWeapon : MonoBehaviour
{
    private PolygonCollider2D pc;

    [SerializeField]
    private float damage;


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            BasicEnemy enemy = col.gameObject.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamageFromBubble(damage);
            }
        }
    }
}
