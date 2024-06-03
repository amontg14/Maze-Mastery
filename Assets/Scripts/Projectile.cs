using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f; // Time before the projectile is destroyed

    void Start()
    {
        // Destroy the projectile after 'lifeTime' seconds
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}