using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    public static int healthValue;
    public int internalHealth;
    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;

    // Start is called before the first frame update
    void Start()
    {
        healthValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        internalHealth = healthValue;

        if (healthValue == 1)
        {
            hearth1.SetActive(true);
        }

        if (healthValue == 2)
        {
            hearth2.SetActive(true);
        }

        if (healthValue == 3)
        {
            hearth3.SetActive(true);
        }
    }
}
