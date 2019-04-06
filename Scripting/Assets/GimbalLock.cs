using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimbalLock : MonoBehaviour {

	float yaw = 0.0f;
	float pitch = 0.0f;
	float roll = 0.0f;

	void Start () {}

	void Update () {
		if (Input.GetKeyUp (KeyCode.Q)) { yaw = 10.0f; }
		if (Input.GetKeyUp (KeyCode.A)) { yaw = -10.0f; }
		if (Input.GetKeyUp (KeyCode.W)) { pitch = 10.0f; }
		if (Input.GetKeyUp (KeyCode.S)) { pitch = -10.0f; }
		if (Input.GetKeyUp (KeyCode.E)) { roll = 10.0f; }
		if (Input.GetKeyUp (KeyCode.D)) { roll = -10.0f; }

		Vector3 rotation = transform.rotation.eulerAngles;
		
		rotation.x += roll;
		rotation.y += yaw;
		rotation.z += pitch;

		transform.rotation = Quaternion.Euler(rotation);

		//transform.Rotate(roll, yaw, pitch, Space.World);

		roll = 0.0f;
		yaw = 0.0f;
		pitch = 0.0f;
	}
}


