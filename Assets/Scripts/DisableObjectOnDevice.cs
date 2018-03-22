using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnDevice : MonoBehaviour {

	public enum Device
	{
		HoloLens,
		VR
	}

	public Device deviceToDisableOn;
	public List<GameObject> objectsToDisable;
	public List<MonoBehaviour> componentsToDisable;

	// Use this for initialization
	void Start () {
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque && deviceToDisableOn == Device.VR)
		{
			foreach (GameObject obj in objectsToDisable)
			{
				obj.SetActive(false);
			}
			foreach (MonoBehaviour component in componentsToDisable)
			{
				component.enabled = false;
			}
		}
		else if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque && deviceToDisableOn == Device.HoloLens)
		{
			foreach (GameObject obj in objectsToDisable)
			{
				obj.SetActive(false);
			}
			foreach (MonoBehaviour component in componentsToDisable)
			{
				component.enabled = false;
			}
		}
	}
}
