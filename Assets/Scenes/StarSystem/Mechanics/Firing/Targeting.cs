using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{

    public GameObject target;

    public Quaternion getFiringDirection()
    {
        float h = Input.mousePosition.x - Screen.width / 2;
        float v = Input.mousePosition.y - Screen.height / 2;

        Vector2 targetPos = target ? target.transform.position : new Vector2(h, v);
        Vector3 spawnPos = transform.position;
        Vector2 directionVector = new Vector2(targetPos.x - spawnPos.x,
                                              targetPos.y - spawnPos.y);
        float angleZ = Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg;

        return Quaternion.Euler(0, 0, -(angleZ));

    }

}
