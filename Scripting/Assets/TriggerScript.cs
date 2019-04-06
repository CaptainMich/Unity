using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	void Start () {	
	}

	void Update () {	
	}
	
	void OnTriggerEnter (Collider other) {
		print (other.gameObject.name + " has entered the cube");		
	}
	
	void OnTriggerStay (Collider other) {
		print (other.gameObject.name + " is still in the cube");		
	}
	
	void OnTriggerExit (Collider other) {
		print (other.gameObject.name + " has left the cube");		
	}
}
