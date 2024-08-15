using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public AudioMixer audioMixer; // Reference to your Audio Mixer
    public Slider bgmSlider; // Reference to your Slider

    private const string BGM_PREF = "BGMVolume"; // Key for saving the volume

    void Start()
    {
        // Load saved volume or set it to a default value if none is found
        float savedVolume = PlayerPrefs.GetFloat(BGM_PREF, 0.75f); // Default volume is 0.75
        bgmSlider.value = savedVolume;

        // Apply the saved volume at startup
        SetBGMVolume(savedVolume);

        // Add a listener to the slider to handle value changes
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    // This function is called when the slider value is changed
    public void SetBGMVolume(float volume)
    {
        // Convert the linear value from the slider to a decibel value
        float dB = LinearToDecibel(volume);

        // Set the BGM volume using the Audio Mixer
        audioMixer.SetFloat("BGMVolume", dB); // "BGMVolume" should be the exposed parameter in the mixer

        // Save the volume setting
        PlayerPrefs.SetFloat(BGM_PREF, volume);
        PlayerPrefs.Save();
    }

    // Helper function to convert linear value to decibel
    private float LinearToDecibel(float linear)
    {
        if (linear != 0)
            return 20.0f * Mathf.Log10(linear);
        else
            return -80.0f; // Usually -80dB is the minimum for Unity mixers
    }
}
