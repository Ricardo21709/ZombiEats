using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingArenaButton : MonoBehaviour
{
    [SerializeField] private FarmingArena farmingArena; // Reference to the FarmingArena script

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the button's trigger collider
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the player exits the button's trigger collider
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Check if the player is in range and presses the "K" key to interact with the button
        if (playerInRange && Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Pressed K to spawn zombies");
            // Call the function to spawn zombies in the Farming Arena
            farmingArena.SpawnZombies(); // You need to implement this function in the FarmingArena script
            Destroy(gameObject);
        }
    }
}

