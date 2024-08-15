using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot normal;
    public AudioMixerSnapshot muffled;

    public GameObject pauseCanvas;

    public string one = "Level01";
    public string two = "Level02";
    public string three = "Level03";

    private bool isPaused;

    private void Start()
    {
        isPaused = false;
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Check if the scene is one of the target scenes and if escape is pressed
        if (currentScene.name == one || currentScene.name == two || currentScene.name == three)
        {
            HandleMuffle();
        }
        else if (!(currentScene.name == one || currentScene.name == two || currentScene.name == three))
        {
            // Ensure normal snapshot is applied when not in target scenes
            normal.TransitionTo(0f);
        }
    }

    void UpdateSnapshot()
    {
        if (isPaused)
            muffled.TransitionTo(0f);
        else
            normal.TransitionTo(0f);
    }

    void HandleMuffle()
    {
        if (pauseCanvas.activeInHierarchy)
        {
            isPaused = true;
            UpdateSnapshot();
        }
        else
        {
            isPaused = false;
            UpdateSnapshot();
        }
    }
}
