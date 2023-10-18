using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array of enemy prefabs
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points
    [SerializeField] private float spawnInterval = 3f; // Time interval between spawns

    void Start()
    {
        // Start spawning enemies at regular intervals
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Infinite loop for continuous spawning
        {
            // Choose a random enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Choose a random spawn point from the array
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the chosen enemy at the random spawn point
            Instantiate(randomEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);

            // Wait for the specified interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
