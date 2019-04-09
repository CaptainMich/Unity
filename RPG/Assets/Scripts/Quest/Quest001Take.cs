using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest001Take : MonoBehaviour
{
    public float Distance;
    public GameObject ActionDisplay; // E key
    public GameObject ActionText;
    public GameObject UIQuest; // quest on screen readable in a full
    public GameObject Player;
    public GameObject NoticeCamera; // different camera to view the quest

    // Update is called once per frame
    void Update()
    {
        // constantly monitor the distance
        Distance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        // check if we are gonna activate the trigger 
        if (Distance <= 3)
        {
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }

        // behaviour of pressing E key 
        if (Input.GetButtonDown("Action"))
        {
            if (Distance <= 3) // check if the player is in range 
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                UIQuest.SetActive(true);
                NoticeCamera.SetActive(true);
                Player.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
}
