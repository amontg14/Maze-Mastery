using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // The starting point
    public Transform pointB; // The ending point
    public float speed = 2f; // Speed of the platform

    private Vector3 target; // Current target point

    private void Start()
    {
        // Set the initial target to pointB
        target = pointB.position;
    }

    private void Update()
    {
        // Move the platform towards the target point
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the platform has reached the target point
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            // Switch target points
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make the player a child of the platform when on it
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove the player from the platform's children when leaving
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}