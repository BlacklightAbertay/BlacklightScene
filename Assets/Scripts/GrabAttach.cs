using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAttach : MonoBehaviour {

	

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
		if (collision.gameObject.tag == "hand")
		{

		}
	}
}
