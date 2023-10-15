using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFiring : MonoBehaviour
{
    public float fireRate = 0.5f;
    private float fireTimer;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && fireTimer <= 0)
        {
            Firing firing = GetComponent<Firing>();
            firing.Fire(() =>
            {
                fireTimer = fireRate; // resets the timer
            });
        }
        fireTimer -= Time.deltaTime;
    }

}
