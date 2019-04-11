using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest001Buttons : MonoBehaviour
{
    public GameObject player;
    public GameObject noticeCamera;
    public GameObject questUI;
    public GameObject activeQuestBox;
    public GameObject objective01;
    public GameObject objective02;
    public GameObject objective03;

    public void AcceptQuest()
    {
        player.SetActive(true);
        noticeCamera.SetActive(false);
        questUI.SetActive(false);
        StartCoroutine(SetQuestUI());
    }

    IEnumerator SetQuestUI()
    {
        activeQuestBox.GetComponent<Text>().text = "My first Weapon";
        objective01.GetComponent<Text>().text = "Reach the clearing in the wood";
        objective02.GetComponent<Text>().text = "Open the cheast";
        objective03.GetComponent<Text>().text = "Retrieve the weapon";

        QuestManager.activeQuestNumber = 1;

        yield return new WaitForSeconds(0.5f);
        activeQuestBox.SetActive(true);
        yield return new WaitForSeconds(1);
        objective01.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        objective02.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        objective03.SetActive(true);
        yield return new WaitForSeconds(9);
        activeQuestBox.SetActive(false);
        objective01.SetActive(false);
        objective02.SetActive(false);
        objective03.SetActive(false);
    }

    public void DeclineQuest()
    {
        player.SetActive(true);
        noticeCamera.SetActive(false);
        questUI.SetActive(false);
    }
}
