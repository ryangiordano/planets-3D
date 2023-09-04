using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 10;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        velocity = new Vector2(h, v).normalized * speed;

        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);
        transform.position += new Vector3(velocity.x * Time.deltaTime, 0, 0);
    }
}
