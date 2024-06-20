using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 1000f;

    private Vector3 offset;
    private float mouseX;
    private float mouseY;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Update camera position relative to player
            transform.position = player.transform.position + offset;

            // Rotate the camera with the right mouse button
            if (Input.GetMouseButton(1))
            {
                mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
                mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // Use -= to invert vertical movement for natural feel
                mouseY = Mathf.Clamp(mouseY, -90f, 90f); // Limit vertical rotation to prevent over-rotation
            }

            // Calculate rotation based on accumulated mouse input
            Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

            // Apply rotation to offset vector to get new camera position
            Vector3 rotatedOffset = rotation * offset;

            // Set camera position
            transform.position = player.transform.position + rotatedOffset;

            // Make the camera look at the player
            transform.LookAt(player.transform.position);
        }
    }
}
