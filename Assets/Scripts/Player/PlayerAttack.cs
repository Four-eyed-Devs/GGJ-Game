using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject bubbleWeapon;

    private ParticleSystem bubblesVFX;

    private void Start()
    {
        bubblesVFX = GetComponentInChildren<ParticleSystem>();
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
        }
        else
        {
            bubbleWeapon.SetActive(false);
            if (bubblesVFX.isPlaying)
            {
                bubblesVFX.Stop();
            }
        }
    }
}
