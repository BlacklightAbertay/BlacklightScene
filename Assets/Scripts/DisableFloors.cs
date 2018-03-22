using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableFloors : MonoBehaviour {

	public List<GameObject> floors;

	// Use this for initialization
	void Start()
	{
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			
		}
	}

	// Update is called once per frame
	void Update() {

	}

	public void SelectFloor(int floor)
	{
		for (int i = floors.Count - 1; i >= 0; i--)
		{
			if (i > floor)
			{
				floors[i].SetActive(false);

			}
			else
			{
				floors[i].SetActive(true);
			}
		}
	}
}
