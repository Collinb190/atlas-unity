using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    AudioSource footstepSound;
    AudioSource fallingSound;
    public float stepInterval = 0.5f; // Interval between footsteps

    private float timeSinceLastStep = 0f;
    private bool isMoving;
    private bool hasMoved = false; // Track if the player has moved since the last step

    public LayerMask groundMask;
    public Transform groundCheck;
    public Transform respawnPoint;
    public float groundDistance = 0.4f;
    public bool isGrounded;
    public bool NotRespawning;
    private bool thumpPlayed = false; // Flag to ensure thump sound plays only once

    private void Start()
    {
        footstepSound = MenuSFX.RunningGrassSoundControl();
        fallingSound = MenuSFX.ThumpGrassSoundControl();
        NotRespawning = true;
    }

    void Update()
    {
        CheckGroundStatus();
        Footsteps();
        StartRespawnProcess();
    }

    void CheckGroundStatus()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void Footsteps()
    {
        isMoving = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");

        if (isMoving && isGrounded && NotRespawning)
        {
            // Play the sound immediately if the player just started moving
            if (!hasMoved)
            {
                footstepSound.PlayOneShot(footstepSound.clip);
                timeSinceLastStep = 0f; // Reset timer for the next interval
                hasMoved = true; // Set flag to true to prevent immediate replay
            }
            else
            {
                timeSinceLastStep += Time.deltaTime;

                // Play sound at regular intervals
                if (timeSinceLastStep >= stepInterval)
                {
                    footstepSound.PlayOneShot(footstepSound.clip);
                    timeSinceLastStep = 0f;
                }
            }
        }
        else
        {
            hasMoved = false; // Reset flag if player stops moving
            timeSinceLastStep = 0f; // Reset timer if no movement
        }
    }

    void StartRespawnProcess()
    {
        if (transform.position == respawnPoint.position && !thumpPlayed)
        {
            NotRespawning = false;
            StartCoroutine(ThumpSound());
            StartCoroutine(ResetSpawnBool());
            thumpPlayed = true; // Ensure the thump sound plays only once
        }
    }

    IEnumerator ResetSpawnBool()
    {
        yield return new WaitForSeconds(9);
        NotRespawning = true;
        thumpPlayed = false; // Reset the flag so the thump sound can play again on next respawn
    }

    IEnumerator ThumpSound()
    {
        yield return new WaitForSeconds(0.9f);
        fallingSound.PlayOneShot(fallingSound.clip);
    }
}
