using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footstepSound;
    public float stepInterval = 0.5f; // Interval between footsteps

    private float timeSinceLastStep = 0f;
    private bool isMoving;
    private bool hasMoved = false; // Track if the player has moved since the last step

    void Update()
    {
        isMoving = Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d");

        if (isMoving)
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
}
