using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCash : MonoBehaviour
{
    public static float goldAmount;
    public float internalGold;
    public GameObject goldDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        internalGold = goldAmount;
        goldDisplay.GetComponent<Text>().text = "GOLD: " + internalGold;
    }
}
