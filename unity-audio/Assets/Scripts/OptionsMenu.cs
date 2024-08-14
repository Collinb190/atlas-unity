using Unity.VisualScripting;
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
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();
        AudioSource porchSwingDaysSound = MenuSFX.PorchSwingDaysSoundControl();
        AudioSource brittleRilleSound = MenuSFX.BrittleRilleSoundControl();
        clickSound.PlayOneShot(clickSound.clip);

        string previousSceneName = SceneTracker.GetPreviousScene();
        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);

            // Check if the previous scene was a level scene
            if (previousSceneName.StartsWith("Level"))
            {
                wallpaperSound.Stop();

                if (previousSceneName.StartsWith("Level01"))
                    cheeryMondaySound.Play();
                else if (previousSceneName.StartsWith("Level02"))
                    porchSwingDaysSound.Play();
                else if (previousSceneName.StartsWith("Level03"))
                    brittleRilleSound.Play();

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

