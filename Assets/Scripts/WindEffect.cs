using UnityEngine;

public class WindEffect : MonoBehaviour
{
    public Vector3 windDirection = new Vector3(1, 0, 0); // Direction of the wind
    public float windStrength = 10f; // Strength of the wind

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 windForce = windDirection.normalized * windStrength;
            rb.AddForce(windForce);
        }
    }

    private void OnDrawGizmos()
    {
        // Visualize the wind direction in the scene view
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + windDirection.normalized * 5f);
    }
}