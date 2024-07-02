using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public CharacterController controller;
    public Transform cam;
    public Transform respawnPoint;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float fallThreshold = -10f;
    public float playerSpeed = 6f;
    public float jumpHeight = 1.5f;
    public float turnSmoothTime = 0.1f;
    public float gravity = -19.62f;
    public float groundDistance = 0.4f;
    public float terminalVelocity = -60f;
    public bool isGrounded;

    private Vector3 velocity;
    private float turnSmoothVelocity;

    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        CheckFellOffWorld();
    }

    void HandleMovement()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -3f;
        }

        // Get input for movement fields
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a movement vector based on the input
        Vector3 moveForce = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        // Move the player using controllers built in Move method
        if (moveForce.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveForce.x, moveForce.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(playerSpeed * Time.deltaTime * moveDirection.normalized);
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }

        // Apply Gravity
        velocity.y += gravity * Time.deltaTime;

        if (velocity.y < terminalVelocity)
        {
            velocity.y = terminalVelocity;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void CheckFellOffWorld()
    {
        // Check if you have fallen past the threshold & respawn
        if (transform.position.y <= fallThreshold)
        {
            transform.position = respawnPoint.position;
            velocity = Vector3.zero;

            // Additional actions upon respawn if needed
            // Example: Reset player health or other game-specific variables
        }
    }
}
