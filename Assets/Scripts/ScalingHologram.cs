using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using HoloToolkit.Unity;

public class ScalingHologram : MonoBehaviour
{
	Vector3 startScale;
	float hololensScale;
	bool isShrunk = false;
	bool isRun = false;
	Vector3 startPositionPlayer;

	private void Start()
	{
		startScale = transform.localScale;
		hololensScale = 0.02f;

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
			if (player.Length > 0 && !isShrunk)
			{
				Debug.Log("Scaling Player");
				
				for (int i = 0; i < player.Length; i++)
				{
					player[i].transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

					if (player.Length > 1)
					{
						isShrunk = true;
					}

					player[1].transform.position = startPositionPlayer;
				}
			}
		}
			
	}

}
