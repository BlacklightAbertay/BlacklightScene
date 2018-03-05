using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;
using HoloToolkit.Unity;
using HoloToolkit.Unity.SpatialMapping;

public class HoloLensUpScale : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.localScale = transform.localScale * 200.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
