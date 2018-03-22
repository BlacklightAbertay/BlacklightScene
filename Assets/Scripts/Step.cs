using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
	public class Step : MonoBehaviour
	{

		public Step otherStep;
		private float _minDistance = 2;
		public Collider collider;
		GameObject player;

		private FadeManager _fadeManager;

		// Use this for initialization
		void Start()
		{
			FadeManager.AssertIsInitialized();
			_fadeManager = FadeManager.Instance;

			player = GameObject.FindGameObjectWithTag("Player");
			collider = gameObject.GetComponent<BoxCollider>();
		}

		// Update is called once per frame
		void Update()
		{
			if (!collider.enabled)
			{
				if (Vector3.Distance(transform.position, player.transform.position) >= _minDistance)
					collider.enabled = true;
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			if (collider.tag == "Player" && !_fadeManager.Busy)
			{
				otherStep.collider.enabled = false;
				_fadeManager.DoFade(0.25f, 0.25f, () =>
				{
					player.transform.position = otherStep.transform.position;
				}, null);
			}
		}
	}
}
