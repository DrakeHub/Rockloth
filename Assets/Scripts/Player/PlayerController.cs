using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float acceleration = 0.1f;
    [SerializeField] private float deceleration = 0.1f;

    [Header("Interaction Settings")]
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private KeyCode inventoryKey = KeyCode.I; // Change to the key you prefer
    
    [SerializeField] private GameObject shop;


    private Rigidbody2D rb;
    private Animator playerAnimator;
    public Animator hatAnimator;
    public Animator torsoAnimator;

    private Vector2 movementInput;
    private bool isInteracting = false;
    private bool isNearShop = false;
    private bool flag = false;

    private Vector2 currentVelocity;

    [SerializeField] private InventoryModel inventoryModel; // Reference to the InventoryModel
    [SerializeField] private InventoryView inventoryView; // Reference to the InventoryView

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent <Animator>();
    }

    private void Update()
    {
        GetInput();
        UpdateAnimation();
        HandleInteraction();
        OpenInventory();
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
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            playerAnimator.SetFloat("X", movementInput.x);
            playerAnimator.SetFloat("Y", movementInput.y);

            playerAnimator.SetBool("isWalking", true);

            if (hatAnimator != null)
            {
                hatAnimator.SetFloat("X", movementInput.x);
                hatAnimator.SetFloat("Y", movementInput.y);

                hatAnimator.SetBool("isWalking", true);
            }
            if (torsoAnimator != null)
            {
                torsoAnimator.SetFloat("X", movementInput.x);
                torsoAnimator.SetFloat("Y", movementInput.y);

                torsoAnimator.SetBool("isWalking", true);
            }
        }
        else
        {            
            if (hatAnimator != null)
            {
                hatAnimator.SetBool("isWalking", false);

            }
            if (torsoAnimator != null)
            {
                torsoAnimator.SetBool("isWalking", false);

            }

            playerAnimator.SetBool("isWalking", false);


        }
    }

    private void HandleInteraction()
    {
        if (isInteracting)
        {

            if (isNearShop) // Adjust the key as needed
            {
                flag = !flag;
                shop.gameObject.SetActive(flag);

            }

            if (!isNearShop && isInteracting && shop.gameObject.activeSelf == true)
            {
                shop.gameObject.SetActive(false);
            }

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
            inventoryView.ToggleInventory(!inventoryView.IsInventoryVisible);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("ClothesShop"))
        {
            isNearShop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClothesShop"))
        {
            isNearShop = false;
            shop.gameObject.SetActive(false);
        }
    }
}
