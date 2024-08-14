using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSFX : MonoBehaviour
{
    private static MenuSFX instance;

    public AudioSource click;
    public AudioSource wallpaper;
    public AudioSource grassRunning;
    public AudioSource rockRunning;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static AudioSource GetButtonClickSound()
    {
        return instance.click;
    }

    public static AudioSource WallpaperSoundControl()
    {
        return instance.wallpaper;
    }

    public static AudioSource RunningGrassSoundControl()
    {
        return instance.grassRunning;
    }

    public static AudioSource RunningRockSoundControl()
    {
        return instance.rockRunning;
    }

}
