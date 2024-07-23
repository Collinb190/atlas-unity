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
        JumpAnimation();
    }

    void JumpAnimation()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetTrigger("isJumping");
        }
    }
}
