using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public bool isInverted;

    // Method to handle back button
    public void Back()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        clickSound.PlayOneShot(clickSound.clip);

        string previousSceneName = SceneTracker.GetPreviousScene();
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);

            // Check if the previous scene was a level scene
            if (previousSceneName.StartsWith("Level"))
            {
                wallpaperSound.Stop();
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
        //Handle Sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

        // Toggle isInverted
        isInverted = !isInverted;

    }

    public void Apply()
    {
        //Handle Sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

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

