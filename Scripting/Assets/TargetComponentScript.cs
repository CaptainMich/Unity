using UnityEngine;
using System.Collections;

public class TargetComponentScript : MonoBehaviour {
	private GameObject target;
	
	void Start () {
		//we can find the object we want by name
		target = GameObject.Find ("Cube");
		
		//we can also find the object we want by its tag
		target = GameObject.FindWithTag ("TargetObject");
	}
	
	// Update is called once per frame
	void Update () {
		//we can access the transform of the target
		//object to manipulate its position. 		
		target.transform.Translate (Input.GetAxis("Horizontal") * .5F, 0F, Input.GetAxis("Vertical") * .5F);
		target.transform.Rotate (Input.GetAxis("Mouse Y") * 3F, -Input.GetAxis("Mouse X") * 3F, 0F);
	}
}
