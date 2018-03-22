using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class PlayerPosition : NetworkBehaviour {

	public GameObject player;
	public GameObject world;
	public NetworkManager netManager;
	public float scale = 0.03f;

	Vector3 positionRelativeToWorld = new Vector3();
	Vector3 rotationRelativeToWorld = new Vector3();

	const short positionMsg = 1002;

	NetworkClient m_client;

	bool initialised = false;

	public class PositionMessage : MessageBase
	{
		public Vector3 positionRelativeToWorld;
		public Vector3 rotationRelativeToWorld;
	}


	// Use this for initialization
	void Start () {
		if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!initialised)
		{
			Init();
			initialised = true;
		}
		else
		{
			if (UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
			{
				positionRelativeToWorld = player.transform.position - world.transform.position;
				rotationRelativeToWorld = player.transform.rotation.eulerAngles - world.transform.rotation.eulerAngles;
				SendPositionMessage(positionRelativeToWorld, rotationRelativeToWorld);
			}
		}

	}

	public void Init()
	{
		m_client = netManager.client;
		NetworkServer.RegisterHandler(positionMsg, OnPositionMessage);
		m_client.RegisterHandler(positionMsg, OnPositionMessage);
	}

	public void SendPositionMessage(Vector3 position, Vector3 rotation)
    {
		PositionMessage msg = new PositionMessage();
		msg.positionRelativeToWorld = position;
		msg.rotationRelativeToWorld = rotation;
        m_client.Send(positionMsg, msg);
    }

	void OnPositionMessage(NetworkMessage netMsg)
	{
		PositionMessage posMessage = netMsg.ReadMessage<PositionMessage>();
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.position = world.transform.position + (posMessage.positionRelativeToWorld * scale);
			transform.rotation = Quaternion.Euler(world.transform.rotation.eulerAngles + posMessage.rotationRelativeToWorld);
		}
	}
}
