using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Method to handle level selection
    public void LevelSelect(int level)
    {
        // Load the corresponding level scene
        string sceneName = "Level" + level.ToString("00");
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }

    // Method to load the Options scene
    public void Options()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        SceneTracker.SetPreviousScene(currentScene.name);
        SceneManager.LoadScene("Options");
    }

    // Method to handle exiting the game
    public void Exit()
    {
        Debug.Log("Exited");
        PlayerPrefs.SetInt("isInverted", 0);
        Application.Quit();
    }
}
