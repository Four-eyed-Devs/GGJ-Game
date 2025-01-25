using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private SpriteRenderer sr;

    public float health; 
    public float maxHealth;
    public Slider PlayerHealthBar;
    public GameOverScreen GameOverScreen;

    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;

    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthBar.value = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            health -= damage;

            StartCoroutine(IFrames());

            if (health <= 0)
            {
                Destroy(gameObject);
                GameOverScreen.Setup();
            }
        }
    }

    private IEnumerator IFrames()
    {
        canTakeDamage = false;

        int temp = 0;

        while(temp < numberOfFlashes)
        {
            sr.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            sr.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }

        canTakeDamage = true;
    }
}
