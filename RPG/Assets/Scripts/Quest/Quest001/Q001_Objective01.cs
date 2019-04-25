using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q001_Objective01 : MonoBehaviour
{
    public GameObject objective;
    public bool closeObjective;

    void Start()
    {
        closeObjective = false;
    }

    // Update is called once per frame
    void Update()
    {
        // make the objective shrink and disappear permanently
        if(closeObjective)
        {
            if(objective.transform.localScale.y <= 0.0f)
            {
                // objective is now complete
                closeObjective = false; 
                objective.SetActive(false);
            }

            else
            {
                objective.transform.localScale -= new Vector3 (0.0f, 0.01f, 0.0f);
            }
        }
    }

    void OnTriggerEnter()
    {
        QuestManager.subQuestNumber = 2;
        this.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(FinishObjective());
    }

    IEnumerator FinishObjective()
    {
        objective.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        closeObjective = true;
    }
}
