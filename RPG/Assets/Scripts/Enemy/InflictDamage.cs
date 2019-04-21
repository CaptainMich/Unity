using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InflictDamage : MonoBehaviour
{
    public int damageAmount = 5;
    public float targetDistance;
    public float allowedRange = 2.00f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && PlayerMovement.combatMode)
        {
            RaycastHit hit;
            if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                targetDistance = hit.distance;

                if(targetDistance <= allowedRange)
                {
                    // send out message to deduct points from our enemies health
                    hit.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
