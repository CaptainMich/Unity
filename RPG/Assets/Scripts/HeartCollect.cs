using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public int RotateSpeed = 2;
    public AudioSource CollectSound;
    public GameObject Heart;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotateSpeed, 0, Space.World);
    }

    void OnTriggerEnter()
    {
        CollectSound.Play();
        HealthMonitor.HealthValue += 1;
        this.Heart.SetActive(false);

    }
}
