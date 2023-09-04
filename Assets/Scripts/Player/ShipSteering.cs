using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAcceleration : MonoBehaviour
{
    public float rotationSpeed = 600;
    public float targetAngle;
    public Direction currentDirection;
    public Direction targetDirection;
    public enum Direction
    {
        Right,
        UpRight,
        DownRight,
        Left,
        UpLeft,
        DownLeft,
        Up,
        Down
    }
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

        if (x > 0 && y > 0)
        {
            targetDirection = Direction.UpRight;
        }
        else if (x > 0 && y < 0)
        {
            targetDirection = Direction.DownRight;
        }
        else if (x < 0 && y > 0)
        {
            targetDirection = Direction.UpLeft;
        }
        else if (x < 0 && y < 0)
        {
            targetDirection = Direction.DownLeft;
        }
        else if (x > 0)
        {
            targetDirection = Direction.Right;
        }
        else if (x < 0)
        {
            targetDirection = Direction.Left;
        }
        else if (y > 0)
        {
            targetDirection = Direction.Up;
        }
        else if (y < 0)
        {
            targetDirection = Direction.Down;
        }

        if (targetDirection != currentDirection)
        {

            switch (targetDirection)
            {
                case Direction.Up:
                    targetAngle = 0f;
                    break;
                case Direction.UpLeft:
                    targetAngle = 45f;
                    break;
                case Direction.Left:
                    targetAngle = 90f;
                    break;
                case Direction.DownLeft:
                    targetAngle = 135f;
                    break;
                case Direction.Down:
                    targetAngle = 180f;
                    break;
                case Direction.DownRight:
                    targetAngle = 225f;
                    break;
                case Direction.Right:
                    targetAngle = 270f;
                    break;
                case Direction.UpRight:
                    targetAngle = 315f;
                    break;
            }

            if (targetAngle != transform.eulerAngles.z)
            {
                Debug.Log("Direction Changing");
                transform.rotation = Quaternion.Euler(
                    0,
                    0,
                    Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime)
                );
            }
            else
            {
                currentDirection = targetDirection;

            }


        }
    }
}
