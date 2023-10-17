using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeVisual : MonoBehaviour
{
    private ShootingController shootingController;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Find the ShootingController script on the player GameObject
        shootingController = transform.parent.GetComponent<ShootingController>();

        // Get the SpriteRenderer component of the AttackRange GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the AttackRange GameObject's size based on the player's attack range
        float scaleMultiplier = shootingController.attackRange * 2f; // Adjust 5f to match your maximum attack range
        transform.localScale = new Vector3(scaleMultiplier, scaleMultiplier, 1f);

        // Set the color and transparency of the AttackRange GameObject
        Color color = Color.gray; // You can adjust the color
        color.a = 0.1f; // Adjust the transparency as needed
        spriteRenderer.color = color;
    }
}
