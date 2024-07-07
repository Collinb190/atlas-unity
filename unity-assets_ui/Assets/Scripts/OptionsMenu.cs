using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
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
}

