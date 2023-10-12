using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 firePointOffset;
    public void Fire(Action callback = null)
    {
        Targeting targeting = GetComponent<Targeting>();

        GameObject projectileInstance = Instantiate(
            projectilePrefab,
            GetFirePointOffset(),
            targeting.getFiringDirection()
        );

        if (callback != null)
        {
            callback();
        }
    }

    private Vector3 GetFirePointOffset()
    {
        return new Vector3(transform.position.x, transform.position.y, 0) + firePointOffset;
    }
}