using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparency : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.2f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
