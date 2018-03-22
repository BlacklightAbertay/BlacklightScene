using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public float oxygenCapacity = 200.0f; // Seconds of oxygen
	float oxygenInTank;
	bool inSmoke = false;

	// Use this for initialization
	void Start ()
	{
		oxygenInTank = oxygenCapacity;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (inSmoke)
		{
			oxygenInTank -= Time.deltaTime;
		}
		else
		{
			oxygenInTank += Time.deltaTime;
			if (oxygenInTank >= oxygenCapacity)
			{
				oxygenInTank = oxygenCapacity;
			}
		}
		if (oxygenInTank <= 0.0f)
		{
			//rip
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "SmokeyArea")
		{
			inSmoke = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "SmokeyArea")
		{
			inSmoke = false;
		}
	}
}
