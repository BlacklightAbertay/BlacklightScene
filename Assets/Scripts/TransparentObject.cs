using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentObject : MonoBehaviour {

	Material originalMaterial;
	Material transparencyMaterial;
	Renderer rend;
	bool isTransparent;

	//testing
	float timeElapsed = 0.0f;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		transparencyMaterial = Resources.Load("transparency") as Material;
		originalMaterial = rend.material;
		ToggleTransparency();
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= 5.0f)
		{
			ToggleTransparency();
			timeElapsed = 0.0f;
		}
	}

	public void ToggleTransparency()
	{
		if (isTransparent)
		{
			isTransparent = false;
			rend.material = originalMaterial;
		}
		else
		{
			isTransparent = true;
			rend.material = transparencyMaterial;
		}
	}
}
