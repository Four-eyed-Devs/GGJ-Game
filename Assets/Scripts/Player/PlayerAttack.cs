using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bubbleWeapon;

    private PlayerMovement pm;

    private ParticleSystem bubblesVFX;

    private void Start()
    {
        bubblesVFX = GetComponentInChildren<ParticleSystem>();

        pm = GetComponentInChildren<PlayerMovement>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            bubbleWeapon.SetActive(true);
            pm.GetAttackAnimIn();
            if (!bubblesVFX.isPlaying)
            {
                bubblesVFX.Play();
            }
        }
        else
        {
            bubbleWeapon.SetActive(false);
            pm.GetAttackAnimOut();
            if (bubblesVFX.isPlaying)
            {
                bubblesVFX.Stop();
            }
        }
    }
}
