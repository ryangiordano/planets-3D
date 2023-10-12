using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFiring : MonoBehaviour
{
    public float detectionRadius = 150f;
    public float fireRate = 0.5f;
    private float fireTimer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Probably can abstract this out into something else more generic and reusable
        // Get position of this object
        Vector3 myPosition = transform.position;

        // Get position of target
        Targeting targeting = GetComponent<Targeting>();

        Vector3 targetPosition = targeting.target.transform.position;

        // Calculate distance between positions
        float distance = Vector3.Distance(myPosition, targetPosition);
        // Check if within detection radius

        if (distance < detectionRadius && fireTimer <= 0)
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
