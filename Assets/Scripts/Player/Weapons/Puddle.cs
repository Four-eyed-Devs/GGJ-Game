using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    [SerializeField]
    private float 
        damage,
        destroyTimer;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("straw");
        Destroy(gameObject, destroyTimer);
    }


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
