using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAcceleration : MonoBehaviour
{
    public float speed;
    public float acceleration = 100;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 input = new Vector2(x, y);
        velocity = Vector2.Lerp(
          velocity,
          velocity + (input * acceleration * Time.deltaTime),
          acceleration * Time.deltaTime
        );

        transform.position += new Vector3(
            velocity.x * Time.deltaTime,
            velocity.y * Time.deltaTime,
            0
        );

        velocity *= 0.99f;
        if (velocity.magnitude > speed)
        {
            velocity = velocity.normalized * speed;
        };
    }
}
