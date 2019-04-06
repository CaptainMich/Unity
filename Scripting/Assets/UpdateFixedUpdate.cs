using UnityEngine;
using System.Collections;

public class UpdateFixedUpdate : MonoBehaviour {

	void Start () {	
	}

	void Update ()	{
   		Debug.Log("Update is called after time : " + Time.deltaTime);
 	}
 
	void FixedUpdate() {
		Debug.Log("Fixed Update is called after time : " + Time.deltaTime);
 	}
}
