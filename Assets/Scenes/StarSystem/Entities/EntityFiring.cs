using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFiring : MonoBehaviour
{
    public float firingRange = 50f;
    public float fireRate = 2f;
    private float fireTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Targeting targeting = GetComponent<Targeting>();
        Detection detection = GetComponent<Detection>();

        float distance = targeting.getDistance();
        if (distance < firingRange && fireTimer <= 0 && detection.alerted)
        {

            // Target is near
            Firing firing = GetComponent<Firing>();
            firing.Fire(() =>
                    {
                        fireTimer = fireRate; // resets the timer
                    });
        }
        else
        {
            // Target too far
        }
        fireTimer -= Time.deltaTime;
    }


}
