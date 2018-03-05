using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour {

	public GameObject player;

	

	// Use this for initialization
	void Start () {
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.position = player.transform.position;
		}

		//if(!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		//{

		//GameObject[] camera = GameObject.FindGameObjectsWithTag("VRPlayer");

		//	if (camera.Length == 2)
		//	{
		//		transform.position = camera[1].transform.position;
		//	}
		//}
	}
}
