using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingArena : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab; // Prefab of the zombie food
    [SerializeField] private float spawnInterval = 1.0f; // Time between zombie spawns
    [SerializeField] private int maxZombies = 10; // Maximum number of zombies in the arena
    private int _currentZombies = 0;
    private bool _isSpawning;
    [SerializeField] private Color gizmoColor = Color.red; // Color for the Gizmo
    [SerializeField] private float spawnRadius = 5.0f; // The radius within which zombies can spawn

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the arena with no zombies
        _currentZombies = 0; 
        _isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SpawnZombies()
    {
        if (_currentZombies < maxZombies)
        {
            StartCoroutine(SpawnZombiesCoroutine());
        }
    }

    public IEnumerator SpawnZombiesCoroutine()
    {
        _isSpawning = true;

        // Spawn zombies until the maximum number is reached
        while (_currentZombies < maxZombies)
        {
            // Randomly calculate a spawn point within the specified radius
            Vector2 randomSpawnPoint = Random.insideUnitCircle * spawnRadius;

            // Instantiate a zombie at the spawn point
            Instantiate(zombiePrefab, transform.position+ new Vector3(randomSpawnPoint.x, randomSpawnPoint.y, 0), Quaternion.identity);

            // Increase the count of current zombies
            _currentZombies++;

            // Wait for the specified spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
        _isSpawning = false;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
