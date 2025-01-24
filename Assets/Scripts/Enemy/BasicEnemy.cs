using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    protected float 
        health,
        damageTimer;

    protected bool canTakeDamageFromBubble;

    // Start is called before the first frame update
    void Start()
    {
        canTakeDamageFromBubble = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamageFromBubble(float amount)
    {
        if (canTakeDamageFromBubble)
        {
            health -= amount;

            canTakeDamageFromBubble = false;

            StartCoroutine(ResetDamageTimer());

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
