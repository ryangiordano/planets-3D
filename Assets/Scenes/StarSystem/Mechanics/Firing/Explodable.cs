using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    public AudioClip explosionSound;

    void OnTriggerEnter(Collider collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();

        if (projectile)
        {
            Debug.Log(projectile);
            Destroy(projectile.gameObject);
            Explode();
        }
    }

    void Explode()
    {
        // Destroy object
        Destroy(gameObject);

        // Spawn particle effect
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        // Play sound effect
        // AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }

}
