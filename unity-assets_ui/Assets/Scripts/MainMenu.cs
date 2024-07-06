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
    }

    // Method to load the Options scene
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    // Method to handle exiting the game
    public void Exit()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
