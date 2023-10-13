using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    public ParticleSystem explosionParticles;
    public AudioClip explosionSound;
    public void SmallExplode()
    {
        // Spawn particle effect
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        // Play sound effect
        // AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }

    public void Explode()
    {
        // Destroy object
        Destroy(gameObject);

        // Spawn particle effect
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        // Play sound effect
        // AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }

}
