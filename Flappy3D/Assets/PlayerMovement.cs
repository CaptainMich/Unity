using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        //rb.AddForce(0,200,500);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //applica una forza ogni frame
        rb.AddForce(0, 0, forwardForce * Time.deltaTime); // time.deltatime serve per eguagliare i diversi frame rate dei computer

        if (Input.GetKey("d")) {
            rb.AddForce(sidewayForce*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown("space") )
        {
            rb.AddForce(0,500 * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

    }
}
