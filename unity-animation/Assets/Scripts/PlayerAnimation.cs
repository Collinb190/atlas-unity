using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public LayerMask groundMask;
    public Transform groundCheck;
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
        RunAnimation();
        IdleAnimation();
    }

    void JumpAnimation()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("isJumping");
        }
    }

    void IdleAnimation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0;

        if (isGrounded && !isMoving)
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isIdle", false);
        }
    }

    void RunAnimation()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0;

        if (isGrounded && isMoving)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
