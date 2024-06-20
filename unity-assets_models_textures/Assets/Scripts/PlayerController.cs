using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public float moveSpeed = 5f;
    public float jumpHeight = 3f;
    public float gravity = -30f;
    public float rotateSpeed = 3000f;
    public float fallThreshold = -10;

    public Transform respawnPoint;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

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
        HandleRotation();
        CheckFellOffWorld();
    }

    #endregion
    #region Custom Methods

    private void InitializeGame()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void HandleMovement()
    {
        // Check if the player is grounded & set velocity to avoid negative build up
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Get input for horizontal and vertical movement and calculate movement direction
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Handle jumping & apply gravity
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleRotation()
    {
        // Get mouse input for rotation
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        // Rotate the player horizontally based on mouse movement
        transform.Rotate(Vector3.up * mouseX);
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
