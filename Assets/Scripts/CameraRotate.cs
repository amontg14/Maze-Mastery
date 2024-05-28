using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform pivot; // Reference to the pivot point
    public float rotationSpeed = 10f; // Speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation
    public Camera mainCamera; // Reference to the main camera
    public float zoomSpeed = 10f; // Speed of zooming
    public float minZoom = 20f; // Minimum field of view
    public float maxZoom = 60f; // Maximum field of view

    void Update()
    {
        HandleRotation();
        HandleZoom();
    }

    void HandleRotation()
    {
        // Check for Q and E key presses and set the rotation direction accordingly
        float rotationInput = 0f;
        
        if (Input.GetKey(KeyCode.Q))
        {
            rotationInput = -1f; // Rotate counter-clockwise
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotationInput = 1f; // Rotate clockwise
        }

        // Rotate the pivot based on input
        pivot.Rotate(rotationAxis, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void HandleZoom()
    {
        // Get scroll wheel input
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        mainCamera.orthographicSize -= scrollInput * zoomSpeed;
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
    }
}