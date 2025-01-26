using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayerPlat : MonoBehaviour
{
    public float healAmount;

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerHealth>().HealDamage(healAmount);
        }    }
}
