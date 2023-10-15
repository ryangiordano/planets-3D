using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolve : MonoBehaviour
{
    private Revolve revolveComponent; // Reference to the Revolve component
    public Vector3 orbitAxis = new Vector3(0, 1, 0.5f);
    public float orbitSpeed = 0.1f;
    public float radius = 3f;
    public float angle = 0f;
    public Transform parent;

    private bool parentDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        revolveComponent = GetComponent<Revolve>();
        DestroyListener destroyListener = parent.gameObject.GetComponent<DestroyListener>();

        if (destroyListener != null)
        {
            destroyListener.OnDestroyEvent += OnObjectDestroyed;
        }
    }

    void OnObjectDestroyed()
    {
        if (revolveComponent != null)
        {
            parentDestroyed = true;
            // The object has been destroyed
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;
            // Generate a random direction for acceleration
            float randomAngle = Random.Range(0f, 360f);

            // Convert the angle to a direction vector
            Vector2 randomDirection = Quaternion.Euler(0f, 0f, randomAngle) * Vector2.right;
            rb.drag = 1;
            // Apply the force in the random direction
            rb.AddForce(randomDirection * Random.Range(100f, 300f), ForceMode.Acceleration);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!parentDestroyed && parent != null)
        {
            angle += orbitSpeed * Time.deltaTime;
            // Calculate the new position based on the center object's position, radius, and angle
            Vector2 newPosition = parent.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

            // Update the position of the object
            transform.position = newPosition;
        }


    }
}
