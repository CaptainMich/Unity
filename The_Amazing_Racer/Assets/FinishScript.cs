using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {

	public GameControlScript gameControlScript;
	
	// When an object enters the finish zone, let the
	// game control know that the current game has ended
	void OnTriggerEnter(Collider other) {
		gameControlScript.FinishedGame();
    }
}
