using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health; 
    public float maxHealth;
    public Slider PlayerHealthBar;
    public GameOverScreen GameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthBar.value = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameOverScreen.Setup();
        }
    }

}
