using UnityEngine;
using System.Collections;

public class CheckScrip : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        print ("Entered: " + gameObject.name);
    }
	
	void OnTriggerExit(Collider other) {
        print ("Exited: " + gameObject.name);
    }
	
	void OnTriggerStay(Collider other) {
        print ("Inside: " + gameObject.name);
    }
}
