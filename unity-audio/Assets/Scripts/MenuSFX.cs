using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuSFX : MonoBehaviour
{
    private static MenuSFX instance;

    public AudioSource click;
    public AudioSource wallpaper;
    public AudioSource cheeryMonday;
    public AudioSource porchSwingDays;
    public AudioSource brittleRille;
    public AudioSource grassRunning;
    public AudioSource grassThump;
    public AudioSource rockRunning;
    public AudioSource rockThump;
    public AudioSource victoryPiano;

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

    public static AudioSource VictoryPianoSoundControl()
    {
        return instance.victoryPiano;
    }

    public static AudioSource WallpaperSoundControl()
    {
        return instance.wallpaper;
    }

    public static AudioSource CheeryMondaySoundControl()
    {
        return instance.cheeryMonday;
    }

    public static AudioSource PorchSwingDaysSoundControl()
    {
        return instance.porchSwingDays;
    }

    public static AudioSource BrittleRilleSoundControl()
    {
        return instance.brittleRille;
    }

    public static AudioSource RunningGrassSoundControl()
    {
        return instance.grassRunning;
    }

    public static AudioSource RunningRockSoundControl()
    {
        return instance.rockRunning;
    }

    public static AudioSource ThumpGrassSoundControl()
    {
        return instance.grassThump;
    }

    public static AudioSource ThumpRockSoundControl()
    {
        return instance.rockThump;
    }
}
