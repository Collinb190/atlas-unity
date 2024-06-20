using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script
    public TextMeshProUGUI timerText; // Reference to the UI Text element for the timer

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.StopTimer(); // Stop the timer
            UpdateTimerTextAppearance(); // Update the timer text appearance
        }
    }

    private void UpdateTimerTextAppearance()
    {
        timerText.fontSize = 60; // Increase the font size
        timerText.color = Color.green; // Change the color to green
    }
}