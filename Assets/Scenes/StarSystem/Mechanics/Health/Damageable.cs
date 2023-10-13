using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Projectile projectile = collision.GetComponent<Projectile>();
        HealthModule healthModule = GetComponent<HealthModule>();
        if (projectile && projectile.originObject != gameObject)
        {
            Destroy(projectile.gameObject);
            int currentHealthPoints = healthModule.decreaseHealth();
            onDecreaseHealth(currentHealthPoints);
        }
    }

    private void onDecreaseHealth(int currentHealthPoints)
    {
        Explodable exlodable = GetComponent<Explodable>();

        if (currentHealthPoints <= 0)
        {
            exlodable.Explode();
        }
        else
        {
            exlodable.SmallExplode();

        }
    }
}
