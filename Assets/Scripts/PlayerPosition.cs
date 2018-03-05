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

	const short positionMsg = 1002;

	NetworkClient m_client;

	bool initialised = false;

	public class PositionMessage : MessageBase
	{
		public Vector3 positionRelativeToWorld;
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
		Debug.Log("update");
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
				SendPositionMessage(positionRelativeToWorld);
			}
		}

	}

	public void Init()
	{
		Debug.Log("Init");
		m_client = netManager.client;
		NetworkServer.RegisterHandler(positionMsg, OnPositionMessage);
		m_client.RegisterHandler(positionMsg, OnPositionMessage);
	}

	public void SendPositionMessage(Vector3 position)
    {
		Debug.Log(position);
		PositionMessage msg = new PositionMessage();
		msg.positionRelativeToWorld = position;
        m_client.Send(positionMsg, msg);
    }

	void OnPositionMessage(NetworkMessage netMsg)
	{
		Debug.Log("position message received");
		PositionMessage posMessage = netMsg.ReadMessage<PositionMessage>();
		if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
		{
			transform.position = world.transform.position + (posMessage.positionRelativeToWorld * scale);
		}
	}
}
