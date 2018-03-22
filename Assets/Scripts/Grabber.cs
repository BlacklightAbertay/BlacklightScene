using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour {

	Rigidbody rBody;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		rBody.transform.position = transform.parent.transform.position;
		rBody.transform.rotation = transform.parent.transform.rotation;
	}

	public void AttachJoint(Rigidbody attachTo)
	{
		FixedJoint joint = GetComponent<FixedJoint>();
		joint.connectedBody = attachTo;
	}

	public void DetachJoint()
	{
		FixedJoint joint = GetComponent<FixedJoint>();
		joint.connectedBody = null;
	}
}
