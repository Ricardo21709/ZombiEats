using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    
    [SerializeField] public float attackRange = 5f; // Set the attack range in the Inspector
    [SerializeField] private float shootingCooldown = 0.5f; // Time delay between shots

    private Transform enemy;
    private float lastShotTime;

    void Update()
    {
        // Find the closest enemy in the attack range
        enemy = FindClosestEnemyInAttackRange();
        
        if (enemy != null)
        {
            RotateTowardsEnemy();
            TryShoot();
        }
    }
    
    Transform FindClosestEnemyInAttackRange()
    {
        // Find all enemy GameObjects in the scene (you can optimize this if needed)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform closestEnemy = null;
        float closestDistance = attackRange; // Initialize to the maximum attack range

        // Iterate through all enemy GameObjects
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within the attack range and closer than the current closest enemy
            if (distanceToEnemy <= attackRange && distanceToEnemy < closestDistance)
            {
                closestEnemy = enemy.transform;
                closestDistance = distanceToEnemy;
            }
        }
        return closestEnemy;
    }

    void RotateTowardsEnemy()
    {
        // If there is a valid enemy, rotate the player towards the enemy
        if (enemy != null)
        {
            Vector2 direction = enemy.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void TryShoot()
    {
        // Implement logic to shoot at the enemy, taking into account the shooting cooldown
        if (Time.time - lastShotTime >= shootingCooldown)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = bulletSpawnPoint.up * bulletSpeed;
        // Customize any additional properties or effects for your bullets
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
