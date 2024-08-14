using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winCanvas;

    public void MainMenu()
    {
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        SceneManager.LoadScene("MainMenu");
        wallpaperSound.Play();
    }

    public void Next()
    {
        AudioSource wallpaperSound = MenuSFX.WallpaperSoundControl();
        AudioSource porchSwingDaysSound = MenuSFX.PorchSwingDaysSoundControl();
        AudioSource brittleRilleSound = MenuSFX.BrittleRilleSoundControl();
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Level03")
        {
            MainMenu();
            wallpaperSound.Play();
        }
        else
        {
            if (currentScene.name == "Level01")
                porchSwingDaysSound.Play();
            else if (currentScene.name == "Level02")
                brittleRilleSound.Play();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
            Time.timeScale = 1.0f;
        }
    }

}
