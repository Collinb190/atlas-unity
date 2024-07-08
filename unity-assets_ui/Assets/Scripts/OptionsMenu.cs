using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public bool isInverted;

    // Method to handle back button
    public void Back()
    {
        string previousSceneName = SceneTracker.GetPreviousScene();
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);

            // Check if the previous scene was a level scene
            if (previousSceneName.StartsWith("Level"))
            {
                // Resume the game if returning to a level scene
                Time.timeScale = 1f;
            };
        }
        else
        {
            Debug.LogWarning("Previous scene not found.");
        }
    }

    public void Invert()
    {
        // Toggle isInverted
        isInverted = !isInverted;

    }

    public void Apply()
    {
        // Save the new isInverted value to PlayerPrefs
        PlayerPrefs.SetInt("isInverted", isInverted ? 1 : 0);

        // Log the status (optional)
        if (isInverted)
        {
            Debug.Log("Inversion toggled ON");
        }
        else
        {
            Debug.Log("Inversion toggled OFF");
        }

        Back();
    }
}

