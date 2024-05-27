using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform pivot; // Reference to the pivot point
    public float rotationSpeed = 10f; // Speed of rotation
    public Vector3 rotationAxis = Vector3.up; // Axis of rotation

    void Update()
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
}