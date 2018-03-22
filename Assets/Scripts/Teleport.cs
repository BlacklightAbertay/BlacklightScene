using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleport : MonoBehaviour
{


	public float floorHeight;


	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void TeleportTo(Vector3 position)
	{
		transform.position = position;
	}

	private void OnTriggerEnter(Collider collider)
	{
		GameObject stepUp = GameObject.FindGameObjectWithTag("StepUp");
		GameObject stepDown = GameObject.FindGameObjectWithTag("StepDown");

		// if the player enters a collision with the step and has not entered at the centre
		if (collider.gameObject == stepUp && transform.position.x != stepUp.transform.position.x && transform.position.z != stepUp.transform.position.z)
		{
			gameObject.transform.position = new Vector3(stepDown.transform.position.x, transform.position.y + floorHeight, stepDown.transform.position.z);
			Debug.Log("colliding with step up");

		}
		else if (collider.gameObject == stepDown && transform.position.x != stepDown.transform.position.x && transform.position.z != stepDown.transform.position.z)
		{
			gameObject.transform.position = new Vector3(stepUp.transform.position.x, transform.position.y - floorHeight, stepUp.transform.position.z);
			Debug.Log("colliding with step down");
		}
	}
}
