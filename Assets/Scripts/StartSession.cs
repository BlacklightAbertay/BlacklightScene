using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using HoloToolkit.Unity.SharingWithUNET;

public class StartSession : MonoBehaviour {

	public bool host = false;

	NetworkDiscoveryWithAnchors networkDiscovery;

	// Use this for initialization
	void Start() {
		if (host) {
			networkDiscovery = NetworkDiscoveryWithAnchors.Instance;
			if (networkDiscovery.running) {
				networkDiscovery.StartHosting("SuperRad");
			}
		}
	}
}
