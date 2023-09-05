using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolve : MonoBehaviour
{
    public Vector3 orbitAxis = new Vector3(0, 1, 0.5f);
    public float orbitSpeed = 36f;
    public Transform parent;
    public Transform child;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        child = transform;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = orbitSpeed * Time.deltaTime;
        child.RotateAround(parent.position, parent.forward, angle);
    }
}
