using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float rollSpeed = 5f;
    private Vector2 moveInput;
    private bool isRolling = false;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        // Handle player input for movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input .GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Handle player input for rolling
        if (Input.GetKeyDown(KeyCode.Space) && !isRolling)
        {
            StartRolling();
        }
    }
    
    private void FixedUpdate()
    {
        // Apply movement if not rolling
        if (!isRolling)
        {
            rb.velocity = moveInput * moveSpeed;
        }
        
        // Rotate the player and their weapon based on the moveInput direction
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void StartRolling()
    {
        isRolling = true;

        // Apply a force to initiate rolling.
        Vector2 rollDirection = moveInput.normalized;
        rb.AddForce(rollDirection * (rollSpeed * 0.5f), ForceMode2D.Impulse);

        // Rolling animation or effects can be added here

        // Allow rolling for a certain duration
        StartCoroutine(StopRolling());
    }
    
    IEnumerator StopRolling()
    {
        // Allow rolling for a certain duration (e.g., half a second)
        yield return new WaitForSeconds(0.5f);

        // Reset rolling
        isRolling = false;
    }
}
