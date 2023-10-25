using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float sprintSpeed = 10f; // Speed when sprinting
    [SerializeField] public float slideSpeed = 5f; // Speed when sliding
    private Vector2 moveInput;
    private bool isSprinting = false;
    private bool isSliding = false;
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

        // Handle player input for sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift); // Assuming Left Shift for sprinting, you can change the key
        
        // Handle player input for rolling
        if (Input.GetKeyDown(KeyCode.C) && !isSliding)
        {
            StartRolling();
        }
    }
    
    private void FixedUpdate()
    {
        // Apply movement if not rolling
        if (!isSliding)
        {
            float currentMoveSpeed = isSprinting ? sprintSpeed : moveSpeed;
            rb.velocity = moveInput * currentMoveSpeed;
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
        isSliding = true;

        // Apply a force to initiate rolling.
        Vector2 rollDirection = moveInput.normalized;
        rb.AddForce(rollDirection * (slideSpeed * 0.5f), ForceMode2D.Impulse);

        // Rolling animation or effects can be added here

        // Allow rolling for a certain duration
        StartCoroutine(StopRolling());
    }
    
    IEnumerator StopRolling()
    {
        // Allow rolling for a certain duration (e.g., half a second)
        yield return new WaitForSeconds(0.3f);

        // Reset rolling
        isSliding = false;
    }
}
