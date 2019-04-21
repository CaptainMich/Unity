using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalExp : MonoBehaviour
{
    public static float currentExp;
    public float internalExp;

    // Update is called once per frame
    void Update()
    {
        internalExp = currentExp;
    }
}
