using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFire : MonoBehaviour {

	public TimerStart timerStart;
	public FlammableObject flammableObject;
	bool fireStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!fireStarted)
		{
			if (timerStart.time > 10.0f)
			{
				flammableObject.StartFire();
				fireStarted = true;
			}
		}
	}
}
