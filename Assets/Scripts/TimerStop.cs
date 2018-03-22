using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerStop : MonoBehaviour {

	public TimerStart timerStart;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		timerStart.Finished();
	}
}
