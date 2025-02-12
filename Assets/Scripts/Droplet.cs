using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    [SerializeField]
    private GameObject splash;

    [SerializeField]
    private float damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Instantiate(splash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Ground"))
        {
            Instantiate(splash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
