using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : MonoBehaviour
{
    public GameObject player;
    public float targetDistance; // to use raycast 
    public float allowedRange; // how far the spider can be before action is taken
    public GameObject enemy;
    public float enemySpeed;
    public int attackTrigger;
    public RaycastHit shot;


    // Start is called before the first frame update
    void Start()
    {
        allowedRange = 30;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            targetDistance = shot.distance;
            if(targetDistance <= allowedRange)
            {
                enemySpeed = 0.05f;
                if (attackTrigger == 0)
                {
                    enemy.GetComponent<Animation>().Play("walk");
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
                }
            }

            else
            {
                enemySpeed = 0;
                enemy.GetComponent<Animation>().Play("idle");
            }
        }

        if (attackTrigger == 1)
        {
            enemySpeed = 0;
            enemy.GetComponent<Animation>().Play("attack");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        attackTrigger = 1;
    }

    void OnCollisionExit(Collision other)
    {
        attackTrigger = 0;
    }
}
