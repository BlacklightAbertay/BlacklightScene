using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceWorldOnHololens : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
