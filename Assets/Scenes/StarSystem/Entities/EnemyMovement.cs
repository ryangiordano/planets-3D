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

            // Convert the angle to a direction vector
            Vector2 dir = getBurstDirection(true) * Vector2.right;

            rb.AddForce(dir * potency, ForceMode.Acceleration);

        }
        burstTimer -= Time.deltaTime;
    }

    Vector2 addRandomNoise(Vector2 baseVec)
    {

        float xNoise = Random.Range(-0.5f, 0.5f);
        float yNoise = Random.Range(-0.5f, 0.5f);

        Vector2 noiseVec = new Vector2(xNoise, yNoise);

        return baseVec + noiseVec;
    }

    public Quaternion getBurstDirection(bool toward)
    {
        Targeting targeting = GetComponent<Targeting>();

        Vector2 direction = (targeting.target.transform.position - transform.position).normalized;

        float angle = Vector2.Angle(Vector2.right, addRandomNoise(direction));

        if (direction.y < 0)
        {
            return Quaternion.Euler(0, 0, angle * (toward ? -1 : 1));
        }
        return Quaternion.Euler(0, 0, angle * (toward ? 1 : -1));
    }

}
