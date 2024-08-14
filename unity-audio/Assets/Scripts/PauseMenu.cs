using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused = false;

    void Update()
    {
        // Check if the Esc key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        //Handle Sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Activate the pause menu
        pauseCanvas.SetActive(true);

        // Unlock and show the cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        //Handle Sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

        // Resume the game
        Time.timeScale = 1f;
        isPaused = false;

        // Deactivate the pause menu
        pauseCanvas.SetActive(false);

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        //Handle Sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();
        AudioSource porchSwingDaysSound = MenuSFX.PorchSwingDaysSoundControl();
        AudioSource brittleRilleSound = MenuSFX.BrittleRilleSoundControl();

        clickSound.PlayOneShot(clickSound.clip);

        // Reload the current scene
        Time.timeScale = 1f; // Ensure the game is not paused
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level01")
            cheeryMondaySound.Stop();
        else if (currentScene.name == "Level02")
            porchSwingDaysSound.Stop();
        else if (currentScene.name == "Level03")
            brittleRilleSound.Stop();

        SceneManager.LoadScene(currentScene.name);

        if (currentScene.name == "Level01")
            cheeryMondaySound.Play();
        else if (currentScene.name == "Level02")
            porchSwingDaysSound.Play();
        else if (currentScene.name == "Level03")
            brittleRilleSound.Play();
    }

    public void MainMenu()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();
        AudioSource porchSwingDaysSound = MenuSFX.PorchSwingDaysSoundControl();
        AudioSource brittleRilleSound = MenuSFX.BrittleRilleSoundControl();

        clickSound.PlayOneShot(clickSound.clip);
        porchSwingDaysSound.Stop();
        brittleRilleSound.Stop();
        cheeryMondaySound.Stop();
        wallpaperSound.Play();

        SceneManager.LoadScene("MainMenu");
    }

    public void Options()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();
        AudioSource porchSwingDaysSound = MenuSFX.PorchSwingDaysSoundControl();
        AudioSource brittleRilleSound = MenuSFX.BrittleRilleSoundControl();

        clickSound.PlayOneShot(clickSound.clip);
        porchSwingDaysSound.Stop();
        brittleRilleSound.Stop();
        cheeryMondaySound.Stop();
        wallpaperSound.Play();

        Scene currentScene = SceneManager.GetActiveScene();

        SceneTracker.SetPreviousScene(currentScene.name);
        SceneManager.LoadScene("Options");
    }
}
