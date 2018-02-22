using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedObjectSegment : MonoBehaviour {

	Rigidbody rBody;
	MeshCollider collider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate(Vector3 explosionCentre, float explosionForce, float explosionRadius, float rBodyMass)
	{
		rBody = gameObject.AddComponent<Rigidbody>();
		rBody.mass = rBodyMass;
		rBody.AddExplosionForce(explosionForce, explosionCentre, explosionRadius);
		collider = gameObject.AddComponent<MeshCollider>();
		collider.convex = true;
	}
}
