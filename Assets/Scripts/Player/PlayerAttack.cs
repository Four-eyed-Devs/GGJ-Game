using System.Collections;
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
        // Get the AudioManager instance dynamically
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (Input.GetMouseButton(0)) // Mouse button is held down
        {
            if (audioManager != null && !audioManager.IsPlaying("bubble_vomit")) // Check if sound is already playing
            {
                audioManager.Play("bubble_vomit"); // Play sound (should be set to loop in AudioManager)
            }

            bubbleWeapon.SetActive(true);
            pm.GetAttackAnimIn();

            if (!bubblesVFX.isPlaying)
            {
                bubblesVFX.Play();
            }
        }
        else // Mouse button is not held down
        {
            if (audioManager != null && audioManager.IsPlaying("bubble_vomit"))
            {
                audioManager.Stop("bubble_vomit"); // Stop looping sound
            }

            bubbleWeapon.SetActive(false);
            pm.GetAttackAnimOut();

            if (bubblesVFX.isPlaying)
            {
                bubblesVFX.Stop();
            }
        }
    }
}