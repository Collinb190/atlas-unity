using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to the UI Text element for displaying the timer

    private float startTime; // Time when the timer starts
    private bool isTimerRunning; // Flag to track if the timer is currently running

    void Start()
    {
        // Set the initial timer text
        timerText.text = FormatTime(0f);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            float elapsedTime = Time.time - startTime;
            timerText.text = FormatTime(elapsedTime);
        }
    }

    public void StartTimer()
    {
        if (!isTimerRunning)
        {
            startTime = Time.time;
            isTimerRunning = true;
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100f) % 100f);

        return string.Format("{0:0}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}
