using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class Hose : MonoBehaviour {

	public InputHandler inputHandler;
	ParticleSystem particleSystem;
	bool spraying = false;

	// Use this for initialization
	void Start () {
		particleSystem = GetComponent<ParticleSystem>();
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
					particleSystem.Play();
					spraying = true;
				}
			}
			else
			{
				particleSystem.Stop();
				spraying = false;
			}
		}
	}
}
