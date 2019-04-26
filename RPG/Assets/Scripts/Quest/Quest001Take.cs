using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001Take : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay; // E key
    public GameObject actionText;
    public GameObject questUI; // quest on screen readable in a full
    public GameObject player;
    public GameObject noticeCamera; // different camera to view the quest
    public GameObject MiniMap;

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
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

        }

        // behaviour of pressing E key 
        if (Input.GetButtonDown("Action"))
        {
            if (distance <= 3) // check if the player is in range 
            {
                MiniMap.SetActive(false);
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                questUI.SetActive(true);
                noticeCamera.SetActive(true);
                player.SetActive(false);

            }
        }
    }

    void OnTriggerExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
