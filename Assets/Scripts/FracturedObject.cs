using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedObject : MonoBehaviour {

	public bool breakOnCollide = false;
	public List<FracturedObjectSegment> segments;

	// Use this for initialization
	void Start ()
	{
		// Get children and apply fractured segment script
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			segments.Add(child.gameObject.AddComponent<FracturedObjectSegment>());
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Break(Vector3? explosionCentre = null, float explosionForce = 0.0f, float explosionRadius = 0.0f)
	{
		if (explosionCentre == null)
			explosionCentre = new Vector3(0.0f, 0.0f, 0.0f);

		Rigidbody rBody = GetComponent<Rigidbody>();

		if (rBody != null)
		{
			rBody.isKinematic = true;
			rBody.detectCollisions = false;
		}

		foreach (FracturedObjectSegment segment in segments)
		{
			segment.Activate(explosionCentre.Value, explosionForce, explosionRadius, rBody.mass/segments.Count);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (breakOnCollide)
		{
			Vector3 explosionPosition = transform.position;
			Break(explosionPosition, 2.0f, 2.0f);
		}
	}

}
