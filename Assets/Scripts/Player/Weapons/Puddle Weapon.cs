  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject puddle;

    [SerializeField]
    private float puddlePlaceTimer;

    protected bool canPlacePuddle;

    void Start()
    {
        canPlacePuddle = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canPlacePuddle)
            {
                Instantiate(puddle, transform.position, Quaternion.identity);
                canPlacePuddle = false;
                StartCoroutine(ResetTimer());
            }
        }
    }

    private IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(puddlePlaceTimer);

        canPlacePuddle = true;
    }
}
