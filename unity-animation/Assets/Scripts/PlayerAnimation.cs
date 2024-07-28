using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterController characterController;
    public LayerMask groundMask;
    public Transform groundCheck;
    public Transform respawnPoint;
    public float groundDistance = 0.4f;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        CheckGroundStatus();
        CheckAnimations();
    }

    void CheckGroundStatus()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void CheckAnimations()
    {
        JumpAnimation();
        IdleOrRunAnimation();
        FallingAnimation();
    }

    void JumpAnimation()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("isJumping");
        }
    }

    void IdleOrRunAnimation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0;

        if (isGrounded)
        {
            if (isMoving)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }
        }
        else
        {
            // Optional: Handle the case when not grounded
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", false);
        }
    }

    void FallingAnimation()
    {
        Vector3 point = new Vector3(0, 1.26f, 0);
        if (transform.position == respawnPoint.position)
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isRunning", false);
        }
        if (transform.position == point)
        {
            animator.SetBool("isFalling", false);
            animator.SetTrigger("isFlat");
            animator.SetTrigger("isGettingUp");
        }
    }    
}
