using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movements : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 50f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    private Vector3 rot_z = new Vector3(0, 0, 1);

    private float hoverHeight = 1.0f;
    private float terrainHeight;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(rot_z * Time.deltaTime * (rotSpeed));
        }

        if (isRotatingLeft == true)
        {
            transform.Rotate(rot_z * Time.deltaTime * (-rotSpeed));
        }

        if (isWalking == true)
        {
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
            // Keep at specific height above terrain
            pos = transform.position;
            float terrainHeight = Terrain.activeTerrain.SampleHeight(pos);
            if (pos.y - terrainHeight != 0)
            {
                transform.position = new Vector3(pos.x, terrainHeight + 273, pos.z);
            }
        }

    }

    // Wander
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }

        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;

    }

}
