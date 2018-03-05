using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using HoloToolkit.Unity;

public class ScalingHologram : MonoBehaviour
{
	Vector3 startScale;
	float hololensScale;
	bool isRun = false;
	Vector3 startPositionPlayer;
	Vector3 lastFramePos;

	private void Start()
	{
		startScale = transform.localScale;
		hololensScale = 0.03f;

		if(!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.localScale = startScale * hololensScale;
			
			isRun = true;

			transform.position = transform.position + Vector3.forward * 0.7f;
			//warper.SetWorldPosition(currentStartTile.transform.position + Vector3.up * 0.8f * transform.localScale.y);

			//THIS DOESNT WORK, THE POSITION IS NOT CHANGED IN THE SCENE
			startPositionPlayer = transform.position;

		}
		if (isRun)
		{
			Debug.Log("Scaling world");
		}
	}

	private void Update()
	{
		//CHECK THIS LOOP, WE GET 2 FPS UNTIL MR PLAYER JOINS UNTIL THEY JOIN BECAUSE OF THE LOOP

		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			GameObject[] player = GameObject.FindGameObjectsWithTag("VRPlayer");
				
			if (player.Length == 2)
			{
				Debug.Log("Scaling Player");
				player[1].transform.localScale = new Vector3(hololensScale, hololensScale, hololensScale);
					
				player[1].transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
				//player[1].transform.position = lastFramePos + ((player[1].transform.position - lastFramePos) * hololensScale);
				//lastFramePos = player[1].transform.position;
			}
		}
	}
}
