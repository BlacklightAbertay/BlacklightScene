using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {

	public Step otherStep;
	public float minDistance;
	public Collider collider;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		collider = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!collider.enabled)
		{
			if (Vector3.Distance(transform.position, player.transform.position) >= minDistance)
				collider.enabled = true;
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Player")
		{
			otherStep.collider.enabled = false;
			player.transform.position = otherStep.transform.position;
		}
	}
}
