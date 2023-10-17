using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private Transform player;

    void Start()
    {
        // Find the player object by tag (you can use a different method to find the player if necessary)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Calculate the direction to move towards the player
        Vector2 moveDirection = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
