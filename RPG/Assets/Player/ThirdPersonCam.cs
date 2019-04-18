using UnityEngine;
using System.Collections;

public class ThirdPersonCam : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private bool click;
    Vector3 startPosition;
    Quaternion startRotation;

    public GameObject player;
    private Quaternion startPlayerRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        startPlayerRotation = player.transform.rotation;
        click = false;
    }

    void Update()
    {
        /**
         *  FIRST METHOD
         * 
         * yaw = speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.V))
        {
            transform.Rotate(-pitch, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.B))
        {
            transform.Rotate(0.0f, yaw, 0.0f);
        }**/

        /**
         * SECOND METHOD
         * 
         * pitch = speedV * Input.GetAxis("Vertical");
        yaw = speedH * Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pitch += speedV;
            transform.Rotate(-pitch, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pitch -= speedV;
            transform.Rotate(-pitch, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.B))
        {

            transform.Rotate(0.0f, yaw, 0.0f);
        }**/
          
        pitch = speedV * Input.GetAxis("Mouse Y");
        yaw = speedH * Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(-pitch, yaw, 0.0f);
            click = true;
        }

        if (Input.GetKey(KeyCode.V) && click)
        {
            if (player.transform.rotation != startPlayerRotation)
            {
                this.transform.rotation = startRotation * ((player.transform.rotation * Quaternion.Inverse(startPlayerRotation)));
                //print(this.transform.rotation);
                // this.transform.position = startPosition;
                //this.transform.rotation = player.transform.rotation;

            }
            else
                this.transform.rotation = startRotation;
            
        }
    } 
}
