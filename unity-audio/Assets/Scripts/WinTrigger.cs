using UnityEngine;
using TMPro;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script
    public TextMeshProUGUI timerText; // Reference to the UI Text element for the timer
    public TextMeshProUGUI finalTime;
    public GameObject winCanvas;
    public GameObject timerCanvas;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.StopTimer(); // Stop the timer
            UpdateTimerTextAppearance(); // Update the timer text appearance
            ActivateWinMenu();
        }
    }

    private void UpdateTimerTextAppearance()
    {
        timerCanvas.SetActive(false);
    }

    public void ActivateWinMenu()
    {
        // Pause the game
        Time.timeScale = 0f;

        // Activate the pause menu
        winCanvas.SetActive(true);

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        finalTime.text = timerText.text;
    }
}
