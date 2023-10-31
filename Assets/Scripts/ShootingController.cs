using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float shootingCooldown = 0.5f;

    private float lastShotTime;

    // Track the currently equipped weapon
    //private BaseWeapon currentWeapon; // You should reference the actual weapon script here

    void Start()
    {
        // Initialize the current weapon (e.g., set it to the melee weapon initially)
        // Replace 'MeleeWeapon' with the actual script/class for your melee weapon
        //currentWeapon = GetComponent<MeleeWeapon>();
    }

    void Update()
    {
        HandleShootingInput();

        // Handle weapon zooming
        if (Input.GetButtonDown("Fire2"))
        {
            ZoomIn();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            ZoomOut();
        }
    }

    void HandleShootingInput()
    {
        if (Input.GetButtonDown("Fire1") && Time.time - lastShotTime >= shootingCooldown)
        {
            lastShotTime = Time.time;
            Shoot();
        }
    }

    void Shoot()
    {
        // if (currentWeapon != null)
        // {
        //     // Shoot using the current weapon
        //     currentWeapon.Shoot();
        // }
    }

    void ZoomIn()
    {
        // Implement zooming logic here
    }

    void ZoomOut()
    {
        // Implement zooming out logic here
    }
}
