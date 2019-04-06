using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour
{
	public GameObject target;

	void Start() {
		StartCoroutine(createCubes());
	}

	void Update() { }

	IEnumerator createCubes()	{
		while(true) {
			yield return new WaitForSeconds(0.3f);
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent<Rigidbody>();
			cube.GetComponent<Renderer>().material.color = Color.green;
			cube.transform.position = target.GetComponent<Transform>().position;
			StartCoroutine(removeCube(cube));
		}
	}

	IEnumerator  removeCube(GameObject cube) {
		yield return new WaitForSeconds(6);
		Destroy(cube);
	}
}
