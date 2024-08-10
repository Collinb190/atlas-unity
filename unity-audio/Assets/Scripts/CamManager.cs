using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject player;
    public GameObject timer;
    public GameObject dummy;
    public GameObject custsceneObject;
    public Animator cutsceneAnimator;   // Reference to the Animator component
    public float animationSpeed = 0.25f; // Speed multiplier for the animation

    void Start()
    {
        player.SetActive(false);
        timer.SetActive(false);
        // Set the speed of the animation
        cutsceneAnimator.speed = animationSpeed;
    }

    public void SwitchToMainCamera()
    {
        custsceneObject.SetActive(false);
        timer.SetActive(true);
        player.SetActive(true);
        dummy.SetActive(false);
    }
}
