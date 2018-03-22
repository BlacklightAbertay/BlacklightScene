using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerStart : MonoBehaviour
{
	bool timerEnabled = false;
	public float time = 0.0f;

	public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(timerEnabled)
		{
			time += Time.deltaTime;
			text.text = time.ToString();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		timerEnabled = true;
	}

	public void Finished()
	{
		timerEnabled = false;
	}
}
