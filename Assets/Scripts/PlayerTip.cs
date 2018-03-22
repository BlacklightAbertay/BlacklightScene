using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTip : MonoBehaviour {

	public GameObject billboard;
	bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!triggered)
		{
			if (other.gameObject.tag == "Player")
			{
				triggered = true;
				billboard.SetActive(true);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			billboard.SetActive(false);
		}
	}
}
