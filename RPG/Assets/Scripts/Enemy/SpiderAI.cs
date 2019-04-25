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
    public bool dealingDamage;


    // Start is called before the first frame update
    void Start()
    {
        player.name = "player";
        allowedRange = 30;
        dealingDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * shot.distance, Color.red);
            Debug.Log("Did Hit " + shot.collider.name);

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
            if (!dealingDamage)
            {
                enemySpeed = 0;
                enemy.GetComponent<Animation>().Play("attack");
                StartCoroutine(TakingDamage());
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "player")
            attackTrigger = 1;
    }

    void OnCollisionExit(Collision other)
    {
        attackTrigger = 0;
    }

    IEnumerator TakingDamage()
    {
        dealingDamage = true;
        yield return new WaitForSeconds(0.5f);
        
        // check if the spider is alive
        if(SpiderEnemy.globalSpider != 6)
        {
            HealthMonitor.healthValue -= 1;
        }

        yield return new WaitForSeconds(0.4f);
        dealingDamage = false;
    }
}
