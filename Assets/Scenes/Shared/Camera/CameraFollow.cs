using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothTime = 0f;

    public float distance = 10;

    private Vector3 velocity;

    void LateUpdate()
    {

        // Get target's current position
        Vector3 targetPos = target.position;
        // Offset to maintain distance
        targetPos += -transform.forward * distance;
        // Smoothly interpolate camera position
        // transform.position = Vector3.SmoothDamp(
        //   transform.position,
        //   targetPos,
        //   ref velocity,
        //   smoothTime
        // );
        transform.position = targetPos;

    }

}