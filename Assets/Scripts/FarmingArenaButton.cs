using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingArenaButton : MonoBehaviour
{
    [SerializeField] private FarmingArena farmingArena; // Reference to the FarmingArena script

    private void Update()
    {
        // Check if the player presses the "K" key to interact with the button
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Call the function to spawn zombies in the Farming Arena
            farmingArena.SpawnZombies(); // You need to implement this function in the FarmingArena script
            Destroy(gameObject);
        }
    }
}
