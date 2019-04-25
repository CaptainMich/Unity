using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene01Skip : MonoBehaviour
{
    public GameObject fadeIn;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeQuit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeQuit()
    {
        yield return new WaitForSeconds(1);
        fadeIn.SetActive(false);
    }
}
