using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the inspector
    public Transform firePoint; // Assign the fire point (the point from which the projectile is fired)
    public float projectileSpeed = 20f; // Speed of the projectile
    public float fireInterval = 1f; // Time between shots

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Fire();
            fireTimer = 0f;
        }
    }

    void Fire()
    {
        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // Get the Rigidbody component from the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        
        // Set the projectile's velocity in the direction of the fire point's forward vector
        rb.velocity = firePoint.forward * projectileSpeed;
    }
}