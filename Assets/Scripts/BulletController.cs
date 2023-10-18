using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int bulletDamage = 1; // Set the bullet damage in the Inspector

    void Start()
    {
        Destroy(gameObject, 2f); // Destroy the bullet after a set time (e.g., 2 seconds)
    }
    
    public void InitializeBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        // Set the bullet's position and rotation
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;

        // Apply velocity to the bullet
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Check if the collided object is an enemy
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            Debug.Log("Hit enemy");
            if (enemyHealth != null)
            {
                // Deal damage to the enemy
                enemyHealth.TakeDamage(bulletDamage);
            }
            
            Destroy(gameObject); // Destroy the bullet upon impact
        }
    }
}
