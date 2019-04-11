using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // assign to each quest in the game a number 
    public static int activeQuestNumber;
    public int internalQuestNumber;

    void Update()
    {
        internalQuestNumber = activeQuestNumber;
    }
}
