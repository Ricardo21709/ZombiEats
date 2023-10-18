using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3; // Set the maximum health in the Inspector
    [SerializeField] private int _currentHealth;
    void Start() 
    { 
        _currentHealth = maxHealth;
    }
    public void TakeDamage(int damage) 
    { 
        _currentHealth -= damage;
        Debug.Log("Enemy current health: " + _currentHealth);

        if (_currentHealth <= 0)
        { 
            Die(); // Enemy defeated
        }
    }
     
    void Die()
    {
        // Implement what happens when the enemy is defeated, e.g., play death animation, award points, or remove the enemy from the scene
        Destroy(gameObject);
    }
}
