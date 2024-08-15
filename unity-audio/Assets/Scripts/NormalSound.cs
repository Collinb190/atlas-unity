using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class NormalSound : MonoBehaviour
{
    public AudioMixerSnapshot normal;

    public string main = "MainMenu";
    public string options = "Options";

    private bool isOnMainOrOptions;

    private void Start()
    {
        isOnMainOrOptions = true;
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == main || currentScene.name == options)
        {
            HandleNormal();
        }
        else if (!(currentScene.name == main || currentScene.name == options))
            isOnMainOrOptions = false;
    }

    void UpdateSnapshot()
    {
        if (isOnMainOrOptions)
            normal.TransitionTo(0f);
    }

    void HandleNormal()
    {
        isOnMainOrOptions = true;
        UpdateSnapshot();
    }
}
