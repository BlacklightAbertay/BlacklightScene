using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAttach : MonoBehaviour {

	GameObject leftHand;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnCollisionStay(Collision collision)
	{
		leftHand = GameObject.FindGameObjectWithTag("hand");
		if (collision.gameObject == leftHand)
		{
			transform.position = leftHand.transform.position;
			Debug.Log("grabbable object colliding with left hand");
		}
	}
}
