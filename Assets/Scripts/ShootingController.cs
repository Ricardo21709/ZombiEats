using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    //[SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float shootingCooldown = 0.5f; // Time delay between shots
    
    private Transform enemy;
    private float lastShotTime;

    void Update()
    {
        RotateTowardsMouse();
        
        // Detect mouse click to shoot
        if (Input.GetButtonDown("Fire1") && Time.time - lastShotTime >= shootingCooldown)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }
    
    void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        SpawnBullet();
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.InitializeBullet(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
