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
    public bool closeObjective; // to check if the objective is close or not
    public GameObject takeSword; // to make the next objective active

    void Start()
    {
        closeObjective = false;
    }


    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

        if(closeObjective)
        {
            objective.SetActive(true);
            if (objective.transform.localScale.y <= 0.0f)
            {
                // objective is now complete
                closeObjective = false;
                objective.SetActive(false);
            }
            else
            {
                objective.transform.localScale -= new Vector3(0.0f, 0.01f, 0.0f);
            }
        }
    }

    void OnTriggerStay()
    {
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Open Chest";
            actionText.SetActive(true);
            actionDisplay.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                treasureChest.GetComponent<Animation>().Play("Q01ChestOpening");
                actionText.SetActive(false);
                actionDisplay.SetActive(false);
                StartCoroutine(FinishObjective());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator FinishObjective()
    {
        objective.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        closeObjective = true;

        yield return new WaitForSeconds(1f);
        takeSword.SetActive(true);


    }

}
