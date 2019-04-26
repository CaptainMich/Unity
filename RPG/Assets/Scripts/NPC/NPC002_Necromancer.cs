using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC002_Necromancer : MonoBehaviour
{
    public int posX;
    public int posZ;
    public GameObject NPCDest;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        posX = Random.Range(975, 990);
        posZ = Random.Range(960, 975);
        NPCDest.transform.position = new Vector3(posX, 6.5f, posZ);
        speed = 0.02f;
        StartCoroutine(RunRandomWalk());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(NPCDest.transform);
        transform.position = Vector3.MoveTowards(transform.position, NPCDest.transform.position, speed);
    }

    IEnumerator RunRandomWalk()
    {
        yield return new WaitForSeconds(5);
        posX = Random.Range(975, 990);
        posZ = Random.Range(960, 975);
        NPCDest.transform.position = new Vector3(posX, 6.5f, posZ);
        speed = 0.02f;
        StartCoroutine(RunRandomWalk());
    }
}
