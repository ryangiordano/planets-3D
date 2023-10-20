using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float potency = 400;
    float burstTimer;
    float burstRate = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (burstTimer < 0)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            burstTimer = burstRate;
            // Generate a random direction for acceleration
            float randomAngle = Random.Range(0f, 360f);
            // Convert the angle to a direction vector
            Vector2 randomDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
            rb.drag = 1;
            rb.AddForce(randomDirection * potency, ForceMode.Acceleration);

        }
        burstTimer -= Time.deltaTime;
    }
}
