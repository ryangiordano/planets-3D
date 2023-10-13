using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthModule : MonoBehaviour
{

    public int maxHealthPoints;
    int currentHealthPoints;
    void Start()
    {
        currentHealthPoints = maxHealthPoints;
    }

    public int decreaseHealth()
    {
        currentHealthPoints--;
        return currentHealthPoints;
    }


}
