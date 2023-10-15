using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StellarBodySize : MonoBehaviour
{
    public float radius = 2f;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate the new scale based on the desired radius
        Vector3 scale = new Vector3(radius, radius, radius);

        // Apply the new scale to the sphere's transform
        transform.localScale = scale;
        // Get the SphereCollider component attached to the sphere
        SphereCollider sphereCollider = GetComponent<SphereCollider>();

        // Set the new radius
        sphereCollider.radius = 0.55f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
