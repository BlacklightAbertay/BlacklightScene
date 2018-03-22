using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class Hose : MonoBehaviour {

	public InputHandler inputHandler;
	public GameObject particleSystem;
	//ParticleSystem particleSystem = null;
	bool spraying = false;

	// Use this for initialization
	void Start () {
		//particleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (inputHandler == null)
		{
			foreach (InputHandler iHandler in FindObjectsOfType<InputHandler>())
			{
				if (iHandler.hand == InteractionSourceHandedness.Left)
				{
					inputHandler = iHandler;
				}
			}
		}
		else
		{
			if (inputHandler.triggerPressed)
			{
				if (!spraying)
				{
					particleSystem.GetComponent<ParticleSystem>().Play();
					spraying = true;
				}
			}
			else
			{
				particleSystem.GetComponent<ParticleSystem>().Stop();
				spraying = false;
			}
		}
	}
}
