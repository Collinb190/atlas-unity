using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Method to handle level selection
    public void LevelSelect(int level)
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        AudioSource cheeryMondaySound = MenuSFX.CheeryMondaySoundControl();

        clickSound.PlayOneShot(clickSound.clip);
        wallpaperSound.Stop();

        // Load the corresponding level scene
        string sceneName = "Level" + level.ToString("00");
        if (sceneName == "Level01")
            cheeryMondaySound.Play();
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    // Method to load the Options scene
    public void Options()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

        Scene currentScene = SceneManager.GetActiveScene();

        SceneTracker.SetPreviousScene(currentScene.name);
        SceneManager.LoadScene("Options");
    }

    // Method to handle exiting the game
    public void Exit()
    {
        // Handle sound
        AudioSource clickSound = MenuSFX.GetButtonClickSound();
        clickSound.PlayOneShot(clickSound.clip);

        Debug.Log("Exited");
        PlayerPrefs.SetInt("isInverted", 0);
        Application.Quit();
    }
}
