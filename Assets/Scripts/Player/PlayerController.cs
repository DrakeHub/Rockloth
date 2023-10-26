using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;

    [Header("Interaction Settings")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode inventoryKey = KeyCode.I; // Change to the key you prefer

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movementInput;
    private bool isInteracting = false;

    private Vector2 currentVelocity;

    [SerializeField] private InventoryModel inventoryModel; // Reference to the InventoryModel
    [SerializeField] private InventoryView inventoryView; // Reference to the InventoryView

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();
    }

    private void Update()
    {
        GetInput();
        UpdateAnimation();
        HandleInteraction();
        OpenInventory(); // Check for opening inventory
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        isInteracting = Input.GetKeyDown(interactKey);
    }

    private void UpdateAnimation()
    {
        // Implement your animation logic here
    }

    private void HandleInteraction()
    {
        if (isInteracting)
        {
            if (inventoryView.IsInventoryVisible)
            {
                // Handle interactions with the open inventory view
                // Implement logic to equip the selected item from the inventory view
                // Example: inventoryModel.EquipSelectedItem(selectedItem);
            }
            else
            {
                // Handle other interactions in the game world
            }
        }
    }

    private void MovePlayer()
    {
        Vector2 targetVelocity = movementInput.normalized * moveSpeed;

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelocity, acceleration, Mathf.Infinity, Time.fixedDeltaTime);

        if (movementInput == Vector2.zero)
        {
            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.zero, ref currentVelocity, deceleration, Mathf.Infinity, Time.fixedDeltaTime);
        }
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            // Toggle the inventory view
            inventoryView.ToggleInventory(!inventoryView.IsInventoryVisible);
        }
    }
}
