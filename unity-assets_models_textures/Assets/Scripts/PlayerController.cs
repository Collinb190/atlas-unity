using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public float moveSpeed = 7.5f;
    public float jumpHeight = 4f;
    public float gravity = -30f;
    public float rotationSpeed = 30f;
    public float fallThreshold = -10f;
    public LayerMask groundMask; // Layers considered as ground

    public Transform respawnPoint;

    private CharacterController controller;
    private Vector3 velocity;
    public bool isGrounded;
    private BoxCollider groundCollider; // Reference to the BoxCollider for ground detection
    private Camera mainCamera;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        CheckFellOffWorld();
    }

    #endregion

    #region Custom Methods

    private void InitializeGame()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get the BoxCollider component
        groundCollider = GetComponent<BoxCollider>();
        if (groundCollider == null)
        {
            Debug.LogError("PlayerController: BoxCollider not found on the player GameObject.");
        }

        mainCamera = Camera.main; // Assuming your main camera is tagged as "MainCamera" in the scene
    }

    private void HandleMovement()
    {
        // Perform a CheckBox to check if the player is grounded
        isGrounded = Physics.CheckBox(groundCollider.bounds.center, groundCollider.bounds.extents, Quaternion.identity, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction relative to camera's forward direction
        Vector3 camForward = mainCamera.transform.forward;
        camForward.y = 0f; // Ignore vertical component to ensure movement stays on the ground
        Vector3 moveDirection = (camForward * moveVertical + mainCamera.transform.right * moveHorizontal).normalized;

        // Rotate player to face movement direction
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Move the player
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Apply gravity
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else if (velocity.y < 0)
        {
            velocity.y = -2f; // Ensure grounded when moving downwards
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply final movement with gravity
        controller.Move(velocity * Time.deltaTime);
    }

    private void FellOffWorld()
    {
        // Teleport the player to the respawn point
        transform.position = respawnPoint.position;
        velocity = Vector3.zero; // Reset velocity to avoid any residual movement

        // Additional actions upon respawn if needed
        // Example: Reset player health or other game-specific variables
    }

    private void CheckFellOffWorld()
    {
        // Check if you have fallen past the threshold
        if (transform.position.y <= fallThreshold)
        {
            FellOffWorld();
        }
    }

    #endregion
}
