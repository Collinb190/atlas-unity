using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script on the Player

    private bool timerStarted; // Flag to track if the timer has started

    void Start()
    {
        timerStarted = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !timerStarted)
        {
            timerScript.enabled = true; // Enable the Timer script
            timerScript.StartTimer(); // Start the timer when Player exits the trigger
            timerStarted = true; // Set flag to true to prevent starting again
        }
    }
}
