using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class GrabAttach : MonoBehaviour {

	GameObject hand;
	InputHandler[] inputHandlers;
	InputHandler attachedHandInputHandler = null;
	Grabber attachedGrabber = null;
	public bool attachedToHand = false;
	Vector3 positionOffset = new Vector3();

	public GameObject swapInventoryItem = null;

	// Use this for initialization
	void Start ()
	{
		inputHandlers = FindObjectsOfType<InputHandler>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DetachFromHand();
	}

	void AttachToHand()
	{
		if (!attachedToHand)
		{
			positionOffset = transform.position - hand.transform.position;
			attachedGrabber.AttachJoint(GetComponent<Rigidbody>());
			attachedToHand = true;
		}
	}

	void DetachFromHand()
	{
		if (attachedHandInputHandler != null)
		{
			if (!attachedHandInputHandler.triggerPressed)
			{
				attachedGrabber.DetachJoint();
				attachedGrabber = null;
				attachedToHand = false;
				attachedHandInputHandler = null;
			}
		}
	}

	private void OnTriggerStay(Collider collider)
	{
		string colliderTag = collider.gameObject.tag;
		if (colliderTag == "RightHand" || colliderTag == "LeftHand")
		{
			hand = collider.gameObject;
			foreach (InputHandler iHandler in inputHandlers)
			{
				if (colliderTag == "RightHand" && iHandler.Handedness == InteractionSourceHandedness.Right && iHandler.triggerPressed)
				{
					attachedGrabber = hand.GetComponent<Grabber>();
					AttachToHand();
					attachedHandInputHandler = iHandler;
					Debug.Log("grabbable object colliding with right hand");
				}
				else if (colliderTag == "LeftHand" && iHandler.Handedness == InteractionSourceHandedness.Left && iHandler.triggerPressed)
				{
					attachedGrabber = hand.GetComponent<Grabber>();
					AttachToHand();
					attachedHandInputHandler = iHandler;
					Debug.Log("grabbable object colliding with left hand");
				}
			}
		}
	}
}
