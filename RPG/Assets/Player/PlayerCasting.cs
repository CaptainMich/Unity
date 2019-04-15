using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceFromTarget; // declare distance we can access from any specific point
    public float toTarget; // declare internal variable to store the distance

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit; 
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),out hit))
        {
            toTarget = hit.distance;
            distanceFromTarget = toTarget;
        }
    }
}
