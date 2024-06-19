using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields

    public float moveSpeed = 5f;
    public float jumpHeight = 3f;
    public float gravity = -30f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    #endregion
    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    #endregion
    #region Custom Methods

    private void HandleMovement()
    {
        // Part 1: Horizontal Movement (Side-to-Side, Forward and Back)
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveHorizontal + transform.forward * moveVertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Part 2: Vertical Movement (Gravity and Jumping)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    #endregion
}
