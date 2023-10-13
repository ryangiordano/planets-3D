using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer;
    public float speed = 50f;
    private float lifespan = 10.3f;
    public Vector3 direction;

    public GameObject originObject;
    // Start is called before the first frame update
    void Start()
    {
        timer = lifespan;
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }

        // Move position along that vector 
        transform.position += transform.TransformDirection(Vector3.up) * speed * Time.deltaTime;
    }
}
