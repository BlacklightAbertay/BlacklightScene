using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FracturedObject : MonoBehaviour {

	public float minimumHitVelocity = 5.0f;
	public int hitsToBreak = 1;
	int hitsTaken = 0;

	public List<FracturedObjectSegment> segments;
	public AudioClip[] hitSounds;
	public AudioClip breakSound;

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

		GetComponent<AudioSource>().clip = breakSound;
		GetComponent<AudioSource>().Play();
	}

	void OnTriggerEnter(Collider other)
	{
		Axe axe = other.gameObject.GetComponent<Axe>();
		if (axe != null)
		{
			if (axe.velocity.magnitude > minimumHitVelocity)
			{
				hitsTaken++;

				int i = Random.Range(0, hitSounds.Length);
				// play hitsounds[i];
				GetComponent<AudioSource>().clip = hitSounds[i];
				GetComponent<AudioSource>().Play();
			}
		}
		if (hitsTaken >= hitsToBreak)
		{
			Vector3 explosionPosition = transform.position;
			Break(explosionPosition, 2.0f, 2.0f);
		}
	}

}
