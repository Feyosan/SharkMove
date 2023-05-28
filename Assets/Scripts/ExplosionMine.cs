using UnityEngine;

public class ExplosionMine : MonoBehaviour
{

    public int damage = 10; // Amount of damage the mine does
    public float explosionForce = 100f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion
    public GameObject explosionPrefab; // Prefab of the explosion

    private bool exploded = false; // Flag to prevent multiple explosions

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !exploded)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Explode();
            }
        }
    }

    void Explode()
    {
        exploded = true;

        // Instantiate the explosion prefab
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destroy the mine object and the explosion prefab
        Destroy(gameObject);
        Destroy(explosion, 2f);
    }
}
