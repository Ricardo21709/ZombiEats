using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // Set the maximum player health in the Inspector
    [SerializeField] private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // Player defeated
        }
    }

    void Die()
    {
        Destroy(gameObject);
        // GameManager.Instance.GameOver();
    }
}
