using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour {
	private int frames = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 axis = new Vector3(0f, 1f, 0f);
		transform.RotateAround(Vector3.zero, axis, 10 * Time.deltaTime);
		
	}
}
