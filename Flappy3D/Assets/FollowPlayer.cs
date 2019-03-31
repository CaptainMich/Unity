using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; //contine 3 float (x,y,z)
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+  offset;  //transform si riferisce a quella dell oggetto corrente
    }
}
