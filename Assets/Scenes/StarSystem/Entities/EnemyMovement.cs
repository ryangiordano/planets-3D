using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float potency = 400;
    float burstTimer;
    float burstRate = .5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Detection detection = GetComponent<Detection>();
        if (burstTimer < 0 && detection.shouldPursue())
        {
            burstTimer = burstRate;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.drag = 1;

            // Generate a random direction for acceleration
            float randomAngle = Random.Range(0f, 360f);
            // Convert the angle to a direction vector
            Vector2 randomDirection = getBurstDirection(true) * Vector2.right;

            rb.AddForce(randomDirection * potency, ForceMode.Acceleration);

        }
        burstTimer -= Time.deltaTime;
    }

    public Quaternion getBurstDirection(bool toward)
    {
        Targeting targeting = GetComponent<Targeting>();
        Vector2 direction = (targeting.target.transform.position - transform.position).normalized;
        float angle = Vector2.Angle(Vector2.right, direction);
        if (direction.y < 0)
        {
            return Quaternion.Euler(0, 0, angle * (toward ? -1 : 1));
        }
        return Quaternion.Euler(0, 0, angle * (toward ? 1 : -1));
    }

}
