using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Q001_Objective03 : MonoBehaviour
{
    public float distance; // reference raycasting from player
    public GameObject fakeSword; // sword in the chest, it will dissapear 
    public GameObject realSword; // the sword in our hand
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject objective;
    public bool closeObjective; // to check if the objective is close or not
    public GameObject chestBlock;
    public GameObject questComplete;
    public GameObject exMark;
    public GameObject light;

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
            objective.SetActive(false);
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
            actionText.GetComponent<Text>().text = "Take Sword";
            actionText.SetActive(true);
            actionDisplay.SetActive(true);
            light.SetActive(true);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3)
            {
                QuestManager.subQuestNumber = 4;
                this.GetComponent<BoxCollider>().enabled = false;
                fakeSword.SetActive(false);
                realSword.SetActive(true);
                chestBlock.SetActive(true);
                actionText.SetActive(false);
                actionDisplay.SetActive(false);
                exMark.SetActive(true);
                questComplete.SetActive(true);
                StartCoroutine(FinishObjective());
            }
        }
    }

    void OnTriggerExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
        light.SetActive(false);
    }

    IEnumerator FinishObjective()
    {
        objective.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        closeObjective = true;
    }

}
