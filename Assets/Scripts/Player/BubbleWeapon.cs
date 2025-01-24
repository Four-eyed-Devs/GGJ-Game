using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWeapon : MonoBehaviour
{
    private PolygonCollider2D pc;

    [SerializeField]
    private float
        damage;

    private bool canTakeDamage;

    private void Awake()
    {
        pc = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<BasicEnemy>().TakeDamageFromBubble(damage);
        }
    }
}
