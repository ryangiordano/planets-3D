using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarSystem.Mechanics;

public class ShipSteering : MonoBehaviour
{
    public float rotationSpeed = 600;
    public float targetAngle;
    public Direction currentDirection = Direction.Up;
    public Direction targetDirection = Direction.Up;

    void Start()
    {

    }

    void Update()
    {
        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;
        float angle = -Mathf.Atan2(v, h) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, -(angle + 90));

    }
}
