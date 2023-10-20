using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemGenerator : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject orbitRingPrefab;
    public GameObject sun;
    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.Find("Sun");
        GenerateAsteroidRing();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /** Generate a ring of random Asteroids around the sun */
    public void GenerateAsteroidRing()
    {
        for (int i = 0; i < 20; i++)
        {
            Vector3 point = GenerateRandomPoint(sun.transform.position, Random.Range(20f, 22f));
            GameObject newAsteroid = Instantiate(asteroidPrefab);
            newAsteroid.transform.position = point;
            newAsteroid.GetComponent<Revolve>().orbitSpeed = Random.Range(0.01f, 0.05f);
            newAsteroid.GetComponent<Revolve>().parent = sun.transform;
            newAsteroid.GetComponent<Revolve>().radius = Random.Range(35, 40);
            newAsteroid.GetComponent<Revolve>().angle = Random.Range(0, 360);
            newAsteroid.GetComponent<StellarBodySize>().radius = Random.Range(1f, 2f);
        }
        // GameObject orbitRing = Instantiate(orbitRingPrefab);
        // orbitRing.transform.position = sun.transform.position;
        // // Set the color alpha value 
        // Material mat = orbitRing.GetComponent<MeshRenderer>().material;
        // Color color = mat.color;
        // color.a = 0.2f;
        // // Apply the color back to the material
        // mat.color = color;
    }


    public Vector3 GenerateRandomPoint(Vector3 point, float radius)
    {
        // Generate random angle 
        float angle = Random.Range(0f, 360f);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        // Generate full position vector
        Vector3 randomPoint;
        randomPoint.x = point.x + x;
        randomPoint.y = point.y + y;
        randomPoint.z = point.z;

        return randomPoint;

    }
}
