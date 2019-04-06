using UnityEngine;
using System.Collections;

public class RaycastScript : MonoBehaviour {

	void Start () {	
	}
	
	void Update () {
		float dirX = Input.GetAxis ("Mouse X");
		float dirY = Input.GetAxis ("Mouse Y");
		transform.Rotate (dirY, -dirX, 0);
		CheckForRaycastHit ();
	}
	
	void CheckForRaycastHit() {
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit)) {
			print (hit.collider.gameObject.name + " destroyed!");
			Destroy (hit.collider.gameObject);
		}
	}
}
