using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammableObject : MonoBehaviour {

	public float timeToPutOut = 5.0f; // Time in seconds it takes to put out this fire
	//public List<GameObject> particleEmitters;
	public List<ParticleSystem> particleSystems;

	public List<float> particleSystemsStartingRates;

	public Renderer distortionRenderer;

	public float fireAmount;
	float extinguishingTime = 0.0f;
	float extinguishingTimePerCollision = 0.5f; // Time in seconds fire is extinguished for when water particle collision detected

	public bool fireOnAwake = true;

	// Use this for initialization
	void Start () {
		if (fireOnAwake)
		{
			fireAmount = timeToPutOut;
		}
		/*Debug.Log(particleEmitters.Count);
		foreach (GameObject obj in particleEmitters)
		{
			ParticleSystem[] particles = obj.GetComponentsInChildren<ParticleSystem>();
			Debug.Log(particles);
			foreach (ParticleSystem system in particles)
			{
				particleSystems.Add(system);
			}
		}*/
		
		for (int i = 0; i < particleSystems.Count; i++)
		{
			ParticleSystem.EmissionModule emissionModule = particleSystems[i].emission;
			particleSystemsStartingRates.Add(emissionModule.rateOverTimeMultiplier);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(fireAmount);
		if (extinguishingTime > 0.0f)
		{
			fireAmount -= Time.deltaTime;
			extinguishingTime -= Time.deltaTime;
			if (fireAmount < 0.0f)
			{
				fireAmount = 0.0f;
			}
		}
		for (int i = 0; i < particleSystems.Count; i++)
		{
			//ParticleSystem.EmissionModule emissionModule = particleSystems[i].emission;
			//emissionModule.rateOverTimeMultiplier = particleSystemsStartingRates[i] * (fireAmount / timeToPutOut);
		}
		distortionRenderer.material.SetFloat("_Strength", 0.03f * (fireAmount / timeToPutOut));
		GetComponent<AudioSource>().volume = fireAmount / timeToPutOut;
	}

	public void StartFire()
	{
		fireAmount = timeToPutOut;
	}

	void OnParticleCollision(GameObject other)
	{
		if (other.tag == "WaterParticles")
		{
			extinguishingTime = extinguishingTimePerCollision;
		}
	}
}
