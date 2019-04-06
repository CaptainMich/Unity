using UnityEngine;
using System.Collections;

public class MotionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xMovement = Input.GetAxis ("Horizontal") / 2;
		float yMovement = Input.GetAxis ("Vertical") / 2;

		transform.Translate (xMovement, yMovement , 0);
	}
}
