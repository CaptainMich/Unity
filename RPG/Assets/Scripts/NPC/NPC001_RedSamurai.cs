using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC001_RedSamurai : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay; // E key
    public GameObject actionText;
    public GameObject textBox;
    public GameObject NPCName;
    public GameObject NPCText;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        // constantly monitor the distance
        distance = PlayerCasting.distanceFromTarget;

    }

    void OnTriggerStay()
    {
        // check if we are gonna activate the trigger 
        if (distance <= 3)
        {
            actionText.GetComponent<Text>().text = "Talk";
            actionDisplay.SetActive(true);
            actionText.SetActive(true);
        }

        // behaviour of pressing E key 
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3) // check if the player is in range 
            {
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                //player.SetActive(false);
                StartCoroutine(NPC001Active());
            }
        }
    }

    void OnTriggerExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator NPC001Active()
    {
        textBox.SetActive(true);
        NPCName.GetComponent<Text>().text = "Giorgio";
        NPCName.SetActive(true);
        NPCText.GetComponent<Text>().text = "Hello friend, I may have a quest for you if you wish to accept it. Please come back later on this afternoon";
        NPCText.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        textBox.SetActive(false);
        NPCName.SetActive(false);
        NPCText.SetActive(false);
        actionDisplay.SetActive(true);
        actionText.SetActive(true);
    }
}
