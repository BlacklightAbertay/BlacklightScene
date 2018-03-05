using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlammableObject : MonoBehaviour {

	public float timeToPutOut = 5.0f; // Time in seconds it takes to put out this fire
	public List<ParticleSystem> particleSystems;

	public List<float> particleSystemsStartingRates;

	float fireAmount;
	float extinguishingTime = 0.0f;
	float extinguishingTimePerCollision = 0.5f; // Time in seconds fire is extinguished for when water particle collision detected

	// Use this for initialization
	void Start () {
		fireAmount = timeToPutOut;
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
		}
		for (int i = 0; i < particleSystems.Count; i++)
		{
			ParticleSystem.EmissionModule emissionModule = particleSystems[i].emission;
			emissionModule.rateOverTimeMultiplier = particleSystemsStartingRates[i] * (fireAmount / timeToPutOut);;
		}
		GetComponent<AudioSource>().volume = fireAmount / timeToPutOut;
	}

	void OnParticleCollision(GameObject other)
	{
		Hose hose = other.GetComponent<Hose>();
		if (hose)
		{
			extinguishingTime = extinguishingTimePerCollision;
		}
	}
}
