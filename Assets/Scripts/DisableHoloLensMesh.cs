using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using HoloToolkit.Unity;

public class DisableHoloLensMesh : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
