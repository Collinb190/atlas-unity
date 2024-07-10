using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winCanvas;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level03")
        {
            MainMenu();
        }
        else
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
            Time.timeScale = 1.0f;
        }
    }

}
