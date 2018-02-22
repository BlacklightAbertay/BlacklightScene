using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class Movement : MonoBehaviour
{
	Vector2 selectorPosition;

	public float force = 5.0f;

	public Rigidbody rb;

	public InputHandler leftInputHandler;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (leftInputHandler == null)
		{
			foreach (InputHandler iHandler in FindObjectsOfType<InputHandler>())
			{
				if (iHandler.hand == InteractionSourceHandedness.Left)
				{
					leftInputHandler = iHandler;
				}
			}
		}
		else
		{
			PlayerMove();
		}
	}

	public void PlayerMove()
	{
		selectorPosition = leftInputHandler.thumbstickPosition;
		Vector3 moveDirection = new Vector3(selectorPosition.x, 0.0f, selectorPosition.y);
		moveDirection = moveDirection.normalized;
		float moveAmount = selectorPosition.magnitude;
		moveDirection = leftInputHandler.transform.rotation * moveDirection;
		//Debug.Log("Hand rotation: " + transform.rotation);

		if (moveAmount > 0.3)
		{
			rb.velocity = moveDirection * force * moveAmount * Time.deltaTime;
			//rb.AddForce(handRotation * transform.forward * moveAmount * 10.0f);
		}
		else
		{
			rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		}

	}

}
