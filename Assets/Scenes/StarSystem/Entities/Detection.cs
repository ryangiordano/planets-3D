using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    float maxApproachRange = 15f;
    float aggroRange = 25f;
    public bool alerted = false;
    public float alertCooldown = 5f;
    public float currentAlertCooldownValue = 5f;


    MeshRenderer renderer;
    Color color = Color.gray;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        Damageable damageable = GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.OnDamageEvent += handleOnDamageReceived;
        }
    }

    void handleOnDamageReceived()
    {
        setAlerted(true);
        currentAlertCooldownValue = alertCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Targeting targeting = GetComponent<Targeting>();
        float distance = targeting.getDistance();
        if (distance < aggroRange)
        {
            setAlerted(true);
            currentAlertCooldownValue = alertCooldown;
        }
        if (currentAlertCooldownValue <= 0)
        {
            setAlerted(false);
        }
        if (alerted)
        {
            currentAlertCooldownValue -= Time.deltaTime;
        }

    }

    public bool shouldPursue()
    {
        Targeting targeting = GetComponent<Targeting>();
        float distance = targeting.getDistance();
        return alerted && distance > maxApproachRange;
    }

    void changeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    void setAlerted(bool isAlert)
    {
        alerted = isAlert;
        changeColor(alerted ? Color.red : Color.gray);
    }
}
