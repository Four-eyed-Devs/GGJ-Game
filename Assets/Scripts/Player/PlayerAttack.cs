using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bubbleWeapon;

    private PlayerMovement pm;

    private ParticleSystem bubblesVFX;
    
    public AudioClip bubblesVomit;

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
            if (!bubblesVFX.isPlaying)
            {
                bubblesVFX.Play();
            }
            pm.GetAttackAnimIn();
        }
        else
        {
            bubbleWeapon.SetActive(false);
            if (bubblesVFX.isPlaying)
            {
                bubblesVFX.Stop();
            }
            pm.GetAttackAnimOut();
        }
    }
}
