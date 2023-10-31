using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public string weaponName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Get the name of the weapon
                string weaponName = this.weaponName;

                // Attach the weapon to the player's hand (you might need to adjust the position and rotation)
                Transform weaponTransform = transform;
                weaponTransform.parent = playerController.handTransform;
                weaponTransform.localPosition = Vector3.zero; // Adjust as needed
                weaponTransform.localRotation = Quaternion.identity; // Adjust as needed

                // Add the weapon to the player's inventory
                playerController.inventory.AddItem(weaponName);

                // Remove the weapon from the scene
                Destroy(gameObject);
            }
        }
    }
}
