using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // assign to each quest in the game a number 
    public static int activeQuestNumber;
    public int internalQuestNumber;

    // variable needed for the pointer
    public GameObject pointer;
    public GameObject mainMark; // place where the arrow will point to
    public GameObject objective01Mark;
    public GameObject objective02Mark;
    public GameObject objective03Mark;
    public GameObject objective04Mark; // complete Quest 001

    public static int subQuestNumber;
    public int internalSubQuestNumber;


    void Start()
    {
        pointer.SetActive(false);
    }

    void Update()
    {
        internalQuestNumber = activeQuestNumber;
        internalSubQuestNumber = subQuestNumber;
        pointer.transform.LookAt(mainMark.transform);

        if (internalSubQuestNumber == 0)
        {
            pointer.SetActive(false);
        }

        else
        {
            pointer.SetActive(true);
        }

        if (internalSubQuestNumber == 1)
        {
            mainMark.transform.position = objective01Mark.transform.position;
        }

        if (internalSubQuestNumber == 2)
        {
            mainMark.transform.position = objective02Mark.transform.position;
        }

        if (internalSubQuestNumber == 3)
        {
            mainMark.transform.position = objective03Mark.transform.position;
        }

        if (internalSubQuestNumber == 4)
        {
            mainMark.transform.position = objective04Mark.transform.position;
        }
    }
}
