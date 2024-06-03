using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform respawnPoint;  // Initial respawn point

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RespawnTrigger"))
        {
            Respawn();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            SetRespawnPoint(other.transform);
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.position;
    }

    void SetRespawnPoint(Transform newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }
}