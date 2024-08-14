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
        clickSound.PlayOneShot(clickSound.clip);

        // Reload the current scene
        Time.timeScale = 1f; // Ensure the game is not paused
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level01")
            cheeryMondaySound.Stop();
        SceneManager.LoadScene(currentScene.name);
        if (currentScene.name == "Level01")
            cheeryMondaySound.Play();
    }

    public void MainMenu()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();
        clickSound.PlayOneShot(clickSound.clip);
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
        clickSound.PlayOneShot(clickSound.clip);
        cheeryMondaySound.Stop();
        wallpaperSound.Play();

        Scene currentScene = SceneManager.GetActiveScene();

        SceneTracker.SetPreviousScene(currentScene.name);
        SceneManager.LoadScene("Options");
    }
}
