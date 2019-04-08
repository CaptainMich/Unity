using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float DistanceFromTarget; // declare distance we can access from any specific point
    public float ToTarget; // declare internal variable to store the distance

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit; 
        if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),out Hit))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}
