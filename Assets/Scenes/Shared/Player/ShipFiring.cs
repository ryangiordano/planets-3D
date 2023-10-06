using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFiring : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 0.5f;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && fireTimer <= 0)
        {
            Fire();
        }
        fireTimer -= Time.deltaTime;
    }
    public Vector3 firePointOffset;
    void Fire()
    {
        GameObject projectileInstance = Instantiate(
            projectilePrefab,
            GetFirePointOffset(),
            GetShipFacing()
        );

        fireTimer = fireRate; // resets the timer
    }

    private Vector3 GetFirePointOffset()
    {
        return new Vector3(transform.position.x, transform.position.y, 0) + firePointOffset;
    }

    private Quaternion GetShipFacing()
    {
        float directionAngle = transform.eulerAngles.z;
        return Quaternion.Euler(0, 0, directionAngle);
    }
}
