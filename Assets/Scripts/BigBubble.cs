using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBubble : MonoBehaviour
{
    [SerializeField]
    private float bigJumpForce;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerMovement>().Jump(bigJumpForce);

            Destroy(gameObject);
        }
    }
}
