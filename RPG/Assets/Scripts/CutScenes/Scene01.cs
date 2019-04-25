using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01 : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject fadeOut;
    public GameObject fadeIn;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutSceneStart());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator CutSceneStart()
    {
        yield return new WaitForSeconds(5);
        camera2.SetActive(true);
        camera1.SetActive(false);
        fadeIn.SetActive(false);
        yield return new WaitForSeconds(10);
        camera3.SetActive(true);
        camera2.SetActive(false);
        yield return new WaitForSeconds(4);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1);
        player.SetActive(true);
        fadeIn.SetActive(true);
        fadeOut.SetActive(false);
        camera3.SetActive(false);
        yield return new WaitForSeconds(1);
    }
}
