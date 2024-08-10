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
        // Reload the current scene
        Time.timeScale = 1f; // Ensure the game is not paused
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }    

    public void Options()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneTracker.SetPreviousScene(currentScene.name);
        SceneManager.LoadScene("Options");
    }
}
