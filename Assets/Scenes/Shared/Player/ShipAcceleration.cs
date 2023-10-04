using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAcceleration : MonoBehaviour
{
    public float speed;
    public float acceleration = 100;
    private Vector2 velocity;

    private float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Quaternion facing = GetShipFacing();
        Vector3 moveDir = facing * Vector3.up;

        float movementAmount = 0;

        if (Input.GetKey(KeyCode.W))
        {
            movementAmount = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementAmount = -1;
        }

        if (movementAmount != 0)
        {

            transform.position += transform.up * Time.deltaTime * speed;

        }

    }
    private Quaternion GetShipFacing()
    {
        float directionAngle = transform.eulerAngles.z;
        return Quaternion.Euler(0, 0, directionAngle);
    }
}
