using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SFXSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider sfxSlider;
    private const string SFXVolumeKey = "SFXVolume";

    void Start()
    {
        // Load saved SFX volume and apply it
        float savedVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 0.75f); // Default value of 0.75
        sfxSlider.value = savedVolume;
        SetSFXVolume(savedVolume);

        // Add listener to call when slider value changes
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetSFXVolume(float sliderValue)
    {
        // Convert linear slider value to decibels
        float dB = LinearToDecibel(sliderValue);
        audioMixer.SetFloat("SFXVolume", dB);

        // Save the slider value
        PlayerPrefs.SetFloat(SFXVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20.0f * Mathf.Log10(linear);
        else
            dB = -80f; // A value low enough to effectively mute the audio
        return dB;
    }

    private void OnDisable()
    {
        // Ensure the listener is removed to avoid memory leaks
        sfxSlider.onValueChanged.RemoveListener(SetSFXVolume);
    }
}
