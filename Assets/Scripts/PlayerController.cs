using System.Collections;
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

    [SerializeField] public PlayerInventory inventory;
    [SerializeField] public Transform handTransform;
    
    private Weapon equippedWeapon; // The currently equipped weapon

    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        // Handle player input for movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        // Handle player input for sprinting
        isSprinting = Input.GetKey(KeyCode.LeftShift); // Assuming Left Shift for sprinting, you can change the key

        // Handle player input for rolling
        if (Input.GetKeyDown(KeyCode.C) && !isSliding)
        {
            StartRolling();
        }
        
        // Handle player input for picking up weapons
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Handle weapon pickup logic
            TryPickupWeapon();
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

    private void TryPickupWeapon()
    {
        // Check if there's a weapon in the vicinity
        Collider2D[] nearbyColliders = Physics2D.OverlapCircleAll(transform.position, 1.5f); // Adjust the radius as needed

        foreach (var collider in nearbyColliders)
        {
            Weapon weapon = collider.GetComponent<Weapon>();
            if (weapon != null)
            {
                // Get the name of the weapon
                string weaponName = weapon.weaponName;

                // Attach the weapon to the player's hand
                Transform weaponTransform = weapon.transform;
                weaponTransform.parent = handTransform; // Make sure 'handTransform' is assigned in the Inspector.
                weaponTransform.localPosition = Vector3.zero; // Adjust as needed
                weaponTransform.localRotation = Quaternion.identity; // Adjust as needed

                // Remove the previously equipped weapon from the player's hand
                if (equippedWeapon != null)
                {
                    // Remove it from the hand
                    equippedWeapon.transform.parent = null;
                }

                // Equip the new weapon
                equippedWeapon = weapon;

                // Add the weapon to the player's inventory
                inventory.AddItem(weaponName);

                // Do not destroy the weapon here

                // Log to check if the weapon is added to the inventory
                Debug.Log("Picked up weapon: " + weaponName);
            }
        }
    }
}