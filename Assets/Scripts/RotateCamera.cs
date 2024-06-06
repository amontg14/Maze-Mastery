using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 20f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
