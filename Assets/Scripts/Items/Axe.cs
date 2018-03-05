using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {

	public Vector3 velocity = new Vector3();

	Vector3 lastFramePosition = new Vector3();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		velocity = (transform.position - lastFramePosition) * (1 / Time.deltaTime);
		lastFramePosition = transform.position;
	}
}
