using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Q001_Objective02 : MonoBehaviour
{
    public float distance; // reference raycasting from player
    public GameObject treasureChest;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject objective;
    public int closeObjective; // to check if the objective is close or not
    public GameObject takeSword; // to make the next objective active

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

        if(closeObjective == 3)
        {
            if (objective.transform.localScale.y <= 0.0f)
            {
                // objective is now complete
                closeObjective = 0;
                objective.SetActive(false);
            }
            else
            {
                objective.transform.localScale -= new Vector3(0.0f, 0.01f, 0.0f);
            }
        }
    }

    void OnMouseOver()
    {
        if(distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Open Chest";
            actionText.SetActive(true);
            actionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if(distance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                treasureChest.GetComponent<Animation>().Play("Q01ChestOpening");
                takeSword.SetActive(true);
                closeObjective = 3;
                actionText.SetActive(false);
                actionDisplay.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

}
