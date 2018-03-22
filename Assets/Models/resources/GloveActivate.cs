using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class GloveActivate : MonoBehaviour {
	private Animator animator;
	public InputHandler inputHandler;

	void Awake () {
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (inputHandler == null)
		{
			foreach (InputHandler iHandler in FindObjectsOfType<InputHandler>())
			{
				if ((iHandler.hand == InteractionSourceHandedness.Left && gameObject.tag == "LeftHand") || (iHandler.hand == InteractionSourceHandedness.Right && gameObject.tag == "RightHand"))
				{
					inputHandler = iHandler;
				}
			}
		}
		else
		{
			if (inputHandler.triggerPressed)
			{
				animator.SetBool("grabTrigger", true);
			}
			else
			{
				animator.SetBool("grabTrigger", false);
			}
		}

		/*
		if (Input.GetKeyDown(KeyCode.E))		//for better control switch bool to float and input to trigger
			if (animator.GetBool("grabTrigger") == true)
				animator.SetBool("grabTrigger", false);
			else
			animator.SetBool("grabTrigger", true);
		*/

	}
}
