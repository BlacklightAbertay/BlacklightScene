using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class InputHandler : AttachToController
{

	public InteractionSourceHandedness hand;
	public Vector2 touchpadPostion = new Vector2(0.0f, 0.0f);
	public bool touchpadTouched = false;

	public Vector2 thumbstickPosition = new Vector2(0.0f, 0.0f);

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	protected override void OnAttachToController()
	{
		// Subscribe to input now that we're parented under the controller
		UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceUpdated += InteractionSourceUpdated;
		hand = handedness;
	}

	protected override void OnDetachFromController()
	{
		// Unsubscribe from input now that we've detached from the controller
		UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceUpdated -= InteractionSourceUpdated;
	}

	private void InteractionSourceUpdated(InteractionSourceUpdatedEventArgs obj)
	{
		if (obj.state.source.handedness == handedness)
		{
			touchpadPostion = obj.state.touchpadPosition;
			touchpadTouched = obj.state.touchpadTouched;
			thumbstickPosition = obj.state.thumbstickPosition;
		}
	}
}
