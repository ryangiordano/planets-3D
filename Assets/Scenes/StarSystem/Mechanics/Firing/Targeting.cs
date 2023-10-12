using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{

    public GameObject target;

    public Quaternion getFiringDirection()
    {
        if (target)
        {
            Vector3 targetPos = target.transform.position;
            Vector3 spawnPos = transform.position;
            Vector2 directionVector = new Vector2(targetPos.x - spawnPos.x,
                                                  targetPos.y - spawnPos.y);
            float angleZ = Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg;
            return Quaternion.Euler(0, 0, -(angleZ));

        }
        else
        {
            float directionAngle = transform.eulerAngles.z;
            return Quaternion.Euler(0, 0, directionAngle);
        }
    }

}
