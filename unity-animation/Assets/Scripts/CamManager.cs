using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject custsceneObject;
    public Animator cutsceneAnimator;   // Reference to the Animator component
    public float animationSpeed = 0.25f; // Speed multiplier for the animation

    void Start()
    {
        // Set the speed of the animation
        cutsceneAnimator.speed = animationSpeed;
    }

    public void SwitchToMainCamera()
    {
        custsceneObject.SetActive(false);
    }
}
